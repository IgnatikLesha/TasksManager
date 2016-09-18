using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Entities;
using BLL.Interfaces;
using TasksManager.Models;
using TasksManager.Providers;

namespace TasksManager.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
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
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = userService.GetByPredicate(u => u.Name == model.Name && u.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password or login");
                }
            }

            return RedirectToAction("Index", "Home", model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }







    }
}