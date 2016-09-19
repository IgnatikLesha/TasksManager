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

        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                //Проверяет учетные данные пользователя и управляет параметрами пользователей
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RememberMe);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        //var user = userService.GetByPredicate(u => u.Email == model.Email && u.Password == model.Password);
        //        //if (user != null)
        //        if (Membership.ValidateUser(model.Email, model.Password))
        //        {
        //            FormsAuthentication.SetAuthCookie(model.Email, true);
        //            return RedirectToAction("About", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Wrong password or login");
        //        }
        //    }

        //    return RedirectToAction("Contact", "Home", model);
        //}

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}