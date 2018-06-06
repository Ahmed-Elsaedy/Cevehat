using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Static()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(user);
        }

        [HttpGet]
        public ActionResult EditAbout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditAbout(ApplicationUser model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditEducation()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult EditEducation(ApplicationUser model)
        {
            return View();
        }

        public ActionResult EditCertification()
        {
            return View();
        }

        public ActionResult EditExperience()
        {
            return View();
        }

        public ActionResult EditSkill()
        {
            return View();
        }
    }
}