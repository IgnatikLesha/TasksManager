using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using TasksManager.Models;

namespace TasksManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userService.GetByPredicate(u => u.Name == User.Identity.Name);
                var tasks = taskService.GetAllByPredicate(t => t.SenderId == user.Id).ToList().GetTasksViewModel();
                ViewBag.Tasks = tasks;
                ViewBag.AllUsers = userService.GetAllEntities();
            }
            return View("MainView");
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