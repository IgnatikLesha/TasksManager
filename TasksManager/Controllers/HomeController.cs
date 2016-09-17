using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using TasksManager.Models;

namespace TasksManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;

        public HomeController(ITaskService taskService, IUserService userService)
        {
            this.taskService = taskService;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userService.GetByPredicate(u => u.Name == User.Identity.Name);
                var tasks = taskService.GetAllByPredicate(t => t.SenderId == user.Id).ToList().GetTasksViewModel();
                ViewBag.Tasks = tasks;
                ViewBag.AllUsers = userService.GetAllEntities();
            }
            return View("Index");
        }

        public ActionResult ShowTasks()
        {
            var user = userService.GetByPredicate(u => u.Name == User.Identity.Name);
            var tasks = taskService.GetAllByPredicate(t => t.RecipientId == user.Id).ToList().GetTasksViewModel();
            ViewBag.User = user;
            ViewBag.Show = false;
            return PartialView("_TasksView", tasks.Tasks);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (userService.GetByPredicate(u => u.Name == model.Name) != null)
            {
                ModelState.AddModelError("", "This name already reserved.");
                return View(model);
            }

            if (userService.GetByPredicate(u => u.Email == model.Email) != null)
            {
                ModelState.AddModelError("", "This address already reserved.");
                return View(model);
            }


            if (ModelState.IsValid)
            {
                var existUser = userService.GetByPredicate(u => u.Email == model.Email && u.Name == model.Name);
                if (existUser == null)
                {
                    userService.Create(new UserEntity
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password

                    });

                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            ViewBag.AllUsers = userService.GetAllEntities();
            return PartialView("_TaskMenu");
        }

        public ActionResult MarkAsChecked(int id)
        {
            var task = taskService.GetById(id);
            if (task != null)
                taskService.MarkAsChecked(task);

            var tasks = taskService.GetAllByPredicate(m => m.Id == id).Select(m => m.GetTaskViewModel()).ToList();
            ViewBag.Show = true;
            return PartialView("_TasksView", tasks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}