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
    [Authorize(Roles = "Employee")]
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

        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Employee,Employer")]
        public ActionResult Details()
        {
            return View(CurrentUser);
        }

        public ActionResult ViewProfile(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.Find(userId);
            return View("Details", user);
        }

        [HttpGet]
        public ActionResult EditPersonal()
        {
            return View(CurrentUser);
        }

        [HttpPost]
        public ActionResult EditPersonal(ApplicationUser model, HttpPostedFileBase profileImage)
        {
            var user = db.Users.Find(model.Id);
            user.Fname = model.Fname;
            user.Lname = model.Lname;
            user.TwitterUrl = model.TwitterUrl;
            user.FacebookUrl = model.FacebookUrl;
            user.LinkinUrl = model.LinkinUrl;
            user.MilitaryStatus = model.MilitaryStatus;
            user.MaritaSutes = model.MaritaSutes;
            user.PhoneNumber = model.PhoneNumber;
            user.Address = model.Address;
            user.Summary = model.Summary;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult EditEducation(int? id)
        {
            if (id.HasValue)
            {
                Education edu = db.Education.Find(id);
                return edu != null ? View(edu) : (ActionResult)HttpNotFound("Id does not exist");
            }
            else
                return View(new Education());
        }

        [HttpPost]
        public ActionResult EditEducation(Education model)
        {
            model.userId = CurrentUser.Id;
            if (model.EducationId == 0)
                db.Education.Add(model);
            else
            {
                Education edu = db.Education.Find(model.EducationId);
                db.Entry(edu).CurrentValues.SetValues(model);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }


        [HttpGet]
        public ActionResult EditExperience(int? id)
        {
            if (id.HasValue)
            {
                Experince exp = db.Experinces.Find(id);
                return exp != null ? View(exp) : (ActionResult)HttpNotFound("Id does not exist");
            }
            else
                return View(new Experince());
        }

        [HttpPost]
        public ActionResult EditExperience(Experince model)
        {
            model.UserID = CurrentUser.Id;
            if (model.ExpId == 0)
                db.Experinces.Add(model);
            else
            {
                Education edu = db.Education.Find(model.ExpId);
                db.Entry(edu).CurrentValues.SetValues(model);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }


        [HttpGet]
        public ActionResult EditCertification(int? id)
        {
            if (id.HasValue)
            {
                Certification cert = db.Certification.Find(id);
                return cert != null ? View(cert) : (ActionResult)HttpNotFound("Id does not exist");
            }
            else
                return View(new Certification());
        }

        [HttpPost]
        public ActionResult EditCertification(Certification model)
        {
            model.userid = CurrentUser.Id;
            if (model.Cerid == 0)
                db.Certification.Add(model);
            else
            {
                Certification edu = db.Certification.Find(model.Cerid);
                db.Entry(edu).CurrentValues.SetValues(model);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }


        public ActionResult AppliedJobs()
        {
            return View(CurrentUser);
        }

        public ActionResult MySkills()
        {
            ViewBag.SkillId = new SelectList(db.Skill.ToList(), "Skill_Id", "Title");
            ViewBag.WeightRange = new SelectList(Enumerable.Range(1, 10));

            var s = CurrentUser;
            return View(CurrentUser);
        }

        [HttpPost]
        public ActionResult AddSkill(int SkillId, int WeightRange)
        {
            ApplicationUser exuser = db.Users.Find(User.Identity.GetUserId());

            Skill skill = db.Skill.Find(SkillId);
            if (CurrentUser.User_TecSkills.FirstOrDefault(x => x.SkillID == SkillId) == null)
            {
                User_Skills user_Skill = new User_Skills()
                {
                    UserId = CurrentUser.Id,
                    SkillID = SkillId,
                    Weight = WeightRange,
                    Skill = skill
                };
                exuser.TecSkills.Add(skill);

                db.User_Skills.Add(user_Skill);
                db.SaveChanges();
            }
            return RedirectToAction("MySkills");
        }

        [HttpGet]
        public ActionResult RemoveSkill(int id)
        {
            ApplicationUser exuser = db.Users.Find(User.Identity.GetUserId());
            
            var local = db.User_Skills.Find(id);
            if (local != null)
            {
                exuser.TecSkills.Remove(db.Skill.Find(local.SkillID));
                db.User_Skills.Remove(local);
                db.SaveChanges();
            }
            return RedirectToAction("MySkills");
        }
    }
}