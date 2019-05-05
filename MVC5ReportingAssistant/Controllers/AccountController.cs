using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC5ReportingAssistant.Identity;
using MVC5ReportingAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC5ReportingAssistant.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Register User
                var userStore = new ApplicationUserStore(_db);
                var userManager = new ApplicationUserManager(userStore);
                var hashPassword = Crypto.HashPassword(model.Password);
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PasswordHash = hashPassword,
                    PhoneNumber = model.PhoneNumber
                };

                var isRegisterSuccessfull = userManager.Create(user);

                if (isRegisterSuccessfull.Succeeded)
                {
                    //Add role to User
                    userManager.AddToRole(user.Id, "User");

                    //Login User
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var userStore = new ApplicationUserStore(_db);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(model.Username, model.Password);

            if (user != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("MyError", "Invalid username and/or password");
                return View();
            }
        }
    }
}