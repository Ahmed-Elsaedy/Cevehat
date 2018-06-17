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
    public class CompanyController : Controller
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

        public ActionResult StaticCompany()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
         
            return View(CurrentUser);
        }

        [HttpGet]
        public ActionResult EditAboutCompany()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
          
            Company comp = db.Company.Find(user.CompanyID);

            return PartialView(comp);
        }


        [HttpPost]
        public ActionResult EditAboutCompany(Company newComp, HttpPostedFileBase img)
        {
            string userId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();
            int? comp_id = currentUser.CompanyID;
            Company comp = db.Company.Where(a => a.CompanyID == comp_id).FirstOrDefault();

            comp.CompanyID = newComp.CompanyID;
            comp.CompanyName = newComp.CompanyName;
            comp.CompanyWebSite = newComp.CompanyWebSite;
            comp.CompanyPhone = newComp.CompanyPhone;
            comp.CompanyInfo = newComp.CompanyInfo;
            comp.CompanyEmail = newComp.CompanyEmail;
            string ext = img.FileName.Substring(img.FileName.LastIndexOf("."));
            comp.CompanyImage = newComp.CompanyID.ToString() + ext;
            db.SaveChanges();
            img.SaveAs(Server.MapPath("~/images/" +newComp.CompanyImage));

            db.SaveChanges();
            return PartialView("StaticAboutCompany", comp);
        }
        [HttpGet]
        public ActionResult jobVacComp()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            int? comp_id = user.CompanyID;
            List<JobVacancie> jobVacs = db.JobVacancie.Where(a => a.CompanyID == comp_id).ToList();

            return PartialView(jobVacs);
        }

        [HttpGet]
        public ActionResult editJobVac(int jobVacId)
        {
            JobVacancie currentJobVac = db.JobVacancie.Where(a => a.JobVacancieID == jobVacId).FirstOrDefault();
            MultiSelectList allSkills = new MultiSelectList(db.Skill, "Skill_Id", "Title", currentJobVac.Skills);
            ViewBag.allSkills = allSkills;
            List<Skill> currentSkills = currentJobVac.Skills.ToList();
            ViewBag.currentSkills = currentSkills;
            List<JobTitle> allJobTitles = db.JobTitle.ToList();
            ViewBag.allJobTitles = allJobTitles;


            return PartialView(currentJobVac);
        }
        [HttpPost]
        public ActionResult editJobVac(JobVacancie newJobVac)
        {
            int jobVacId = newJobVac.JobVacancieID;
            JobVacancie jobVac = db.JobVacancie.Where(a=> a.JobVacancieID==jobVacId).FirstOrDefault();
            jobVac.JobTitle.JobName = newJobVac.JobTitle.JobName;
            jobVac.ExpYears = newJobVac.ExpYears;
            jobVac.JobType = newJobVac.JobType;
            jobVac.Skills = newJobVac.Skills;
            db.SaveChanges();
            return PartialView("StaticAboutCompany",jobVac );
        }








    }
}