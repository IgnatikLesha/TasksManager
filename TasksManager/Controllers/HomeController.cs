using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Mappers;
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

            return View(taskService.GetAllEntities().Select(t=>t.GetTaskViewModel()));
        }

        public ActionResult ShowAllTasks()
        {
            return View(taskService.GetAllEntities().Select(t => t.GetTaskViewModel()));
        }



        [HttpGet]
        public ActionResult CreateTask()
        {
            ViewBag.AllUsers = userService.GetAllEntities();
            //return View(userService.GetAllEntities().Select(t => t.GetUserViewModel()));
            return PartialView("CreateTask");
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel task, string toUser)
        {
            var userId = userService.GetByPredicate(u => u.Name == toUser);
            var thisUser = userService.GetByPredicate(u => u.Name == User.Identity.Name);
            task.SenderId = thisUser.Id;
            task.RecipientId = userId.Id;

            int id = taskService.CreateTask(new TaskEntity
            {
                Name = task.Name,
                Checked = task.Checked,
                CreationDate = task.CreationDate,
                Description = task.Description,
                SenderId = task.SenderId,
                RecipientId = task.RecipientId
            });
            ViewBag.TaskIdNew = id;
            return PartialView("CreateTask");
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