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
        public string Phone { get; set; }
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

        public ActionResult Static()
        {
            return View(CurrentUser);
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
            return PartialView("StaticAbout", _currentUser);
        }


        [HttpGet]
        public ActionResult EditEducation(int? educationId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Education edu = educationId.HasValue ? db.Education.Find(educationId) : new Education();
                return PartialView(edu);
            }
        }

        [HttpPost]
        public ActionResult EditEducation(Education model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.userId = CurrentUser.Id;
                if (model.EducationId != 0)
                {
                    Education edu = db.Education.Find(model.EducationId);
                    db.Entry(edu).CurrentValues.SetValues(model);
                }
                else
                    db.Education.Add(model);
                db.SaveChanges();
                var user = db.Users.FirstOrDefault(a => a.Id == model.userId);
                return PartialView("StaticEducation", CurrentUser);
            }
        }


        [HttpGet]
        public ActionResult EditExperience(int? experienceId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Experince exp = experienceId.HasValue ? db.Experinces.Find(experienceId) : new Experince();
                return PartialView(exp);
            }
        }

        [HttpPost]
        public ActionResult EditExperience(Experince model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.UserID = CurrentUser.Id;
                if (model.ExpId != 0)
                {
                    Experince exp = db.Experinces.Find(model.ExpId);
                    db.Entry(exp).CurrentValues.SetValues(model);
                }
                else
                    db.Experinces.Add(model);
                db.SaveChanges();
                var user = db.Users.FirstOrDefault(a => a.Id == model.UserID);
                return PartialView("StaticExperience", CurrentUser);
            }
        }


        [HttpGet]
        public ActionResult EditCertification(int? Cerid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Certification cer = Cerid.HasValue ? db.Certification.Find(Cerid) : new Certification();
                return PartialView(cer);
            }
        }

        [HttpPost]
        public ActionResult EditCertification(Certification model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.userid = CurrentUser.Id;
                if (model.Cerid != 0)
                {
                    Certification cer = db.Certification.Find(model.Cerid);
                    db.Entry(cer).CurrentValues.SetValues(model);
                }
                else
                    db.Certification.Add(model);
                db.SaveChanges();
                var user = db.Users.FirstOrDefault(a => a.Id == model.userid);
                return PartialView("StaticCertification", CurrentUser);
            }
        }
    }
}