using GETProject.Models;
using GETProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GETProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {   
        
        private ProjectContext _context;
        public AccountController()
        {
            _context = new ProjectContext();
        }
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user) {
            if (!ModelState.IsValid)
                return View("Register", user);
            if (_context.Users.Where(u => u.Email == user.Email || u.UserName == user.UserName).Any()) {
                ModelState.AddModelError("Email", "Username or email already exists");
                return View("Register", user);
            }
            user.RoleId = 3;
            _context.Users.Add(user);
            _context.SaveChanges();

            return Content("Registration is successfull");
        }
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            //WebRoleProvider webRoleProvider = new WebRoleProvider();
            if (!ModelState.IsValid)
                return View("Login", user);
            var loginUser = _context.Users.Where(u=>u.UserName==user.UserName && u.Password==user.Password).FirstOrDefault();

            if (loginUser == null) {
                ModelState.AddModelError("UserName", "User Name or Password are incorecct, try again");
                return View("Login",user);
            }
            else{
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = loginUser.UserName;
                return RedirectToAction("Index","Home");
            }
            return View(user);
                   
        }

        
        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}