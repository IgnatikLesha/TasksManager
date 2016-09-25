﻿using System;
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
            return PartialView("CreateTask");
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel task, string toUser)
        {
            var userId = userService.GetByPredicate(u => u.Name == toUser);
            var thisUser = userService.GetByPredicate(u => u.Email == User.Identity.Name);
            task.SenderId = thisUser.Id;
            task.RecipientId = userId.Id;

            taskService.Create(new TaskEntity
            {
                Name = task.Name,
                Checked = task.Checked,
                CreationDate = task.CreationDate,
                Description = task.Description,
                SenderId = task.SenderId,
                RecipientId = task.RecipientId
            });
            return PartialView("Index");
        }

        public ActionResult ShowMyTasks()
        {
            var user = userService.GetByPredicate(u => u.Email == User.Identity.Name);
            var tasks = taskService.GetAllByPredicate(t => t.SenderId == user.Id).ToList();//.GetTasksViewModel();
            ViewBag.User = user;
            ViewBag.tasks = tasks;
            return PartialView("ShowMyTasks");
        }

        public ActionResult TasksForMe()
        {
            var user = userService.GetByPredicate(u => u.Email == User.Identity.Name);
            var tasks = taskService.GetAllByPredicate(t => t.RecipientId == user.Id).ToList();//.GetTasksViewModel();
            ViewBag.User = user;
            ViewBag.tasks = tasks;
            return PartialView("TasksForMe");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Tasks Manager. Created by Lesha Ignatik. ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contacts:.";

            return View();
        }
        public void SetDone(string id)
        {
            int taskId = Convert.ToInt32(id);
            var task = taskService.GetById(taskId);
            if (task.Checked == false)
            {
                task.Checked = true;
            }
        }
    }
}