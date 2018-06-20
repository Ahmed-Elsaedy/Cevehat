using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
           ApplicationDbContext db = new ApplicationDbContext();
           string userId =  User.Identity.GetUserId();
           ApplicationUser newUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();
            return RedirectToAction("Index", "Default");
            //return PartialView(newUser);
        }

        public ActionResult About()
        { 
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}