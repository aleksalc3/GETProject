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
    public class TaskController : Controller
    {
        private ProjectContext _context;

        public TaskController()
        {
            _context = new ProjectContext();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {

            var _projects = _context.Projects.ToList();
            var _users = _context.Users.ToList();
            var viewModel = new ProjectFormModel
            {
                Task = new Task(),
                Projects= _projects,
                Users=_users
                

            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", task);
            }
            if (task.Id > 0)
                _context.Entry(task).State = EntityState.Modified;
            else
                _context.Tasks.Add(task);

            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var task = _context.Tasks.SingleOrDefault(c => c.Id == id);

            if (task == null)
                return HttpNotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _task = _context.Tasks.SingleOrDefault(p => p.Id == id);

            if (_task == null)
                return HttpNotFound();

            var viewModel = new ProjectFormModel
            {
                Task = _task,
                Projects = _context.Projects.ToList(),
                Users = _context.Users.ToList()
            };
            return View("Create", viewModel);
        }

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {

            var tasks = _context.Tasks.Include(c => c.Project).Include(u=>u.User).ToList();


            return View(tasks);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}