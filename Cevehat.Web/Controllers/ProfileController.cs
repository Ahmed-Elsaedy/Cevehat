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
    public class AboutViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public MaritalStutes MaritaSutes { get; set; }
        public string Address { get; set; }
        public string Summary { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedUrl { get; set; }
    }

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
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            AboutViewModel viewModel = new AboutViewModel()
            {
                FirstName = user.Fname,
                LastName = user.Lname,
                Address = user.Address,
                FacebookUrl = user.FacebookUrl,
                Gender = user.Gender,
                LinkedUrl = user.LinkinUrl,
                MilitaryStatus = user.MilitaryStatus,
                Summary = user.Summary,
                TwitterUrl = user.TwitterUrl
            };
            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult EditAbout(AboutViewModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string userId = User.Identity.GetUserId();
            ApplicationUser _currentUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();

            _currentUser.Fname = model.FirstName;
            _currentUser.Lname = model.LastName;
            _currentUser.Gender = model.Gender;
            _currentUser.MilitaryStatus = model.MilitaryStatus;
            _currentUser.MaritaSutes = model.MaritaSutes;
            _currentUser.Address = model.Address;
            _currentUser.Summary = model.Summary;
            _currentUser.FacebookUrl = model.FacebookUrl;
            _currentUser.LinkinUrl = model.LinkedUrl;
            _currentUser.TwitterUrl = model.TwitterUrl;

            db.SaveChanges();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


        [HttpGet]
        public ActionResult EditEducation()
        {
            
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditEducation(ApplicationUser model)
        {
            return PartialView();
        }

        public ActionResult Certification()
        {
            string userId = User.Identity.GetUserId();
            //List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            return View();
        }
        // GET: Certification/Create
        [HttpGet]
        public ActionResult CreateCertification()
        {
            string userId = User.Identity.GetUserId();
            //List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            //ViewBag.allCertification = cert;
            return View();
        }
        // POST: Certification/Create
        [HttpPost]
        public ActionResult CreateCertification([Bind(Exclude ="Cerid")] Certification cert)
        {
            try
            {
                cert.userid= User.Identity.GetUserId();
                //db.Certification.Add(cert);
                //db.SaveChanges();
                return RedirectToAction("Certification");
            }
            catch
            {
                return View();
            }
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