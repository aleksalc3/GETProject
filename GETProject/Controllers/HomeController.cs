using GETProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GETProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.FirstName = "IT4Solutions";
            ViewBag.LastName = "Youtube Chanell";
            return View();
        }

        
            
            
            
    }
}