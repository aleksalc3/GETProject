using GETProject.Models;
using GETProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GETProject.Controllers
{
    
    public class ProjectController : Controller
    {
        private ProjectContext _context;
        public ProjectController()
        {
            _context = new ProjectContext();
        }
        [AllowAnonymous]
        // GET: Project
        public ActionResult Index()
        {

            var projects = _context.Projects.ToList();
            return View(projects);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Create() {
            return View(new Project { Id = 0 }); 
        
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrator,Project Manager")]
        public ActionResult Create(Project _project)
        {
            if (!ModelState.IsValid) {
                return View("Create",_project);
            }
            if (_project.Id > 0)
                _context.Entry(_project).State = EntityState.Modified;
            else
                _context.Projects.Add(_project);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var project = _context.Projects.SingleOrDefault(c => c.Id == id);

            if (project == null)
                return HttpNotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _project = _context.Projects.SingleOrDefault(c => c.Id == id);

            if (_project == null)
                return HttpNotFound();

            return View("Create",_project);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}