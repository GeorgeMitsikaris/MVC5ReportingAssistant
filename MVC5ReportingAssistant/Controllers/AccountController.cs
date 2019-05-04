using MVC5ReportingAssistant.Identity;
using MVC5ReportingAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5ReportingAssistant.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(RegisterViewModel model)
        //{
           
        //}
    }
}