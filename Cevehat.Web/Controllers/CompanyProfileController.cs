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
        
        public ActionResult Details()
        {
            return View(CurrentUser);
        }
        [HttpGet,Authorize(Roles = "Employer")]
        public ActionResult EditDetails()
        {
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }
        [HttpPost, Authorize(Roles = "Employer")]
        public ActionResult EditDetails(Company newComp, HttpPostedFileBase img)
        {
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);

            currentComp.CompanyID = newComp.CompanyID;
            currentComp.CompanyName = newComp.CompanyName;
            currentComp.CompanyWebSite = newComp.CompanyWebSite;
            currentComp.CompanyPhone = newComp.CompanyPhone;
            currentComp.CompanyInfo = newComp.CompanyInfo;
            currentComp.CompanyEmail = newComp.CompanyEmail;
            string ext = img.FileName.Substring(img.FileName.LastIndexOf("."));
            currentComp.CompanyImage = newComp.CompanyID.ToString() + ext;
            db.SaveChanges();

            img.SaveAs(Server.MapPath("~/images/") + currentComp.CompanyImage);

            db.SaveChanges();
            return RedirectToAction("Details");
        }
        [Authorize(Roles="Employer")]
        public ActionResult userApplications()
        {
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }

        [Authorize(Roles = "Employer")]
        public ActionResult RecentJobs()
        {
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }

        
        [Authorize(Roles = "Employer")]
        public ActionResult ChangeState(int id)
        {
            JobVacancie currentJob= db.JobVacancie.Find(id);
            
                currentJob.State = State.Closed;
                db.SaveChanges();
            
            return RedirectToAction("RecentJobs");
        }

        [Authorize(Roles = "Employer")]
        public ActionResult ArchivedJobs()
        {
            Company currentComp = db.Company.Find(CurrentUser.CompanyID);
            return View(currentComp);
        }





    }
}.