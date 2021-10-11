using GETProject.Models;
using GETProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GETProject.Controllers
{
    public class UserController : Controller
    {
        private ProjectContext _context;

        public UserController()
        {
            _context = new ProjectContext();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            
            var _roles = _context.Roles.ToList();
            var viewModel = new UserViewModel
            {
                User = new User(),
                
                Roles = _roles

            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", user);
            }
            if (user.Id > 0)
                _context.Entry(user).State = EntityState.Modified;
            else
                _context.Users.Add(user);

            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (_user == null)
                return HttpNotFound();

            var viewModel = new UserViewModel
            {
                User = _user,
                
                Roles= _context.Roles.ToList()
            };
            return View("Create", viewModel);
        }

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {

            var users = _context.Users.ToList();


            return View(users);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}