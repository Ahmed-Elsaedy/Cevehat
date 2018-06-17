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
    public class UserProfileController : Controller
    {
        private ApplicationUser _CurrentUser;
        public ApplicationUser CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                    _CurrentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                return _CurrentUser;
            }
        }

        // GET: UserProfile
        public ActionResult Details()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult EditPersonal()
        {
            return View(CurrentUser);
        }

        [HttpPost]
        public ActionResult EditPersonal(ApplicationUser model)
        {

            return RedirectToAction("Details");
        }
    }
}