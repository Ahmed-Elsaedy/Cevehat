﻿using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public partial class DefaultController
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

        public ActionResult UserProfile()
        {
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult EditUserProfile()
        {
            return View(CurrentUser);
        }

    }
}