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
   
    public class CompanyProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
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
        [Authorize(Roles="Employee,Employer")]
        public ActionResult ShowDetails(int JobVacancieID)
        {
            JobVacancie currentJob = db.JobVacancie.Find(JobVacancieID);
            bool IsApplyed = false;
            string userid = User.Identity.GetUserId();
            foreach (ApplayedUsers apuser in currentJob.ApplayedUsers)
            {
                if (apuser.UserId == userid)
                {
                    IsApplyed = true;
                }
            }
            ViewBag.IsApplyed = IsApplyed;
            return View(currentJob);
        }
        [Authorize(Roles = "Employee")]
        public ActionResult ViewProfile(int CompanyId)
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            var company = db.Company.Find(CompanyId);
            if(company==null)
            {
                return HttpNotFound("Company Not Found");
            }
            return View(company);
        }
        [Authorize(Roles = "Employer")]
        public ActionResult Details()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            return View(CurrentUser);
        }
        [HttpGet, Authorize(Roles = "Employer")]
        public ActionResult EditDetails()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }
        [HttpPost, Authorize(Roles = "Employer")]
        public ActionResult EditDetails(Company newComp, HttpPostedFileBase img)
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);

            currentComp.CompanyID = newComp.CompanyID;
            currentComp.CompanyName = newComp.CompanyName;
            currentComp.CompanyWebSite = newComp.CompanyWebSite;
            currentComp.CompanyPhone = newComp.CompanyPhone;
            currentComp.CompanyInfo = newComp.CompanyInfo;
            currentComp.CompanyEmail = newComp.CompanyEmail;

            if (img != null)
            {
                string ext = img.FileName.Substring(img.FileName.LastIndexOf("."));
                currentComp.CompanyImage = newComp.CompanyID.ToString() + ext;
                img.SaveAs(Server.MapPath("~/images/") + currentComp.CompanyImage);
            }

            db.SaveChanges();
            return RedirectToAction("Details");
        }
        [Authorize(Roles = "Employer")]
        public ActionResult userApplications()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }

        [Authorize(Roles = "Employer")]
        public ActionResult RecentJobs()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }


        [Authorize(Roles = "Employer")]
        public ActionResult ChangeState(int id)
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            JobVacancie currentJob = db.JobVacancie.Find(id);
            if (currentJob.State == State.Active)
            {
                currentJob.State = State.Closed;
                db.SaveChanges();
                return RedirectToAction("RecentJobs");
            }
            else
            {
                currentJob.State = State.Active;
                db.SaveChanges();
                return RedirectToAction("ArchivedJobs");

            }
        }

        [Authorize(Roles = "Employer")]
        public ActionResult ArchivedJobs()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }

        [HttpGet, Authorize(Roles = "Employer")]
        public ActionResult AddJob()
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            JobVacancie newjob = new JobVacancie();
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            newjob.Date = DateTime.Now;
            newjob.CompanyID = currentComp.CompanyID;
            newjob.Company = currentComp;
            newjob.Company = currentComp;

            SelectList jobTitles = new SelectList(db.JobTitle.ToList(), "JobId", "JobName");
            ViewBag.JobTitles = jobTitles;

            MultiSelectList jobSkills = new MultiSelectList(db.Skill.ToList(), "Skill_Id", "Title");
            ViewBag.JobSkills = jobSkills;

            return View(newjob);
        }

        [HttpPost, Authorize(Roles = "Employer")]
        public ActionResult AddJob(JobVacancie newjob, List<int> Skills)
        {
            ViewBag.lastLogin = CurrentUser.LastLogin;
            db.JobVacancie.Add(newjob);
            for (int i = 0; i < Skills.Count; i++)
            {
                Skill currentskill = db.Skill.Find(i);
                newjob.Skills.Add(currentskill);
            }

            db.SaveChanges();
            return RedirectToAction("RecentJobs");
        }
    }
}