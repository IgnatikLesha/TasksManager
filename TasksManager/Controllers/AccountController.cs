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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Name, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (userService.GetByPredicate(u => u.Email == model.Email) != null)
            {
                ModelState.AddModelError("", "This address already reserved.");
                return View(model);
            }
            if (userService.GetByPredicate(u => u.Name == model.Name) != null)
            {
                ModelState.AddModelError("", "This name already reserved.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var existUser = userService.GetByPredicate(u => u.Email == model.Email && u.Name == model.Name);
                if (existUser == null)
                {
                    userService.Create(new UserEntity
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.Name
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


    }
}