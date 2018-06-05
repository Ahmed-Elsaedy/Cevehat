using Microsoft.AspNet.Identity;
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
            return View();
        }

        public ActionResult EditAbout()
        {
            return View();
        }

        public ActionResult EditEducation()
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