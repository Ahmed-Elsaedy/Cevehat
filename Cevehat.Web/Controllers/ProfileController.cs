using Cevehat.Web.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Static()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(user);
        }
       

        [HttpGet]//Get Action to view data to user
        public ActionResult EditAbout()
        {
            //create object of db context
            ApplicationDbContext db = new ApplicationDbContext();

            //Get user by ID and user attached to this ID "Global"
            string userId = User.Identity.GetUserId();
            ApplicationUser _currentUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();

            //Get list of all required and send it with a "ViewBag" 
            List<string> _allGenders = Enum.GetNames(typeof(Gender)).ToList();
            List<string> _allMilitaryStatus = Enum.GetNames(typeof(MilitaryStatus)).ToList();
            List<string> _allMaritalStatus = Enum.GetNames(typeof(MaritalStutes)).ToList();

            //drop down list take a thing of type "SelectListItem"
            List<SelectListItem> _genderList = new List<SelectListItem>();
            List<SelectListItem> _MilitarList = new List<SelectListItem>();
            List<SelectListItem> _MaritalList = new List<SelectListItem>();

            //iteration list of genders
            foreach (var item in _allGenders)
            {
                bool _IsSelected = false;
                if (_currentUser.Gender.ToString() == item.ToString())
                {
                    _IsSelected = true;
                }
                _genderList.Add(new SelectListItem() { Text = item, Value = item, Selected = _IsSelected });
            }
            //iteration list of Marital status
            foreach (var item in _allMaritalStatus)
            {
                bool _IsSelected = false;
                if (_currentUser.MaritaSutes.ToString() == item.ToString())
                {
                    _IsSelected = true;
                }
                _MaritalList.Add(new SelectListItem() { Text = item, Value = item, Selected = _IsSelected });
            }
            //iteration list of Military status
            foreach (var item in _allMilitaryStatus)
            {
                bool _IsSelected = false;
                if (_currentUser.MilitaryStatus.ToString() == item.ToString())
                {
                    _IsSelected = true;
                }
                _MilitarList.Add(new SelectListItem() { Text = item, Value = item, Selected = _IsSelected });
            }
            //return all viewbags with all lists => Gender / military Status / Marital Status
            ViewBag.MilitaryList = _MilitarList;

            ViewBag.MaritalList = _MaritalList;

            ViewBag.GendersList = _genderList;
            return View(_currentUser);
        }


        public ActionResult EditAbout2(ApplicationUser model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string userId = User.Identity.GetUserId();
            ApplicationUser _currentUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();
            _currentUser.Fname = model.Fname;
            _currentUser.Lname = model.Lname;
            _currentUser.Gender = model.Gender;
            _currentUser.MilitaryStatus = model.MilitaryStatus;
            _currentUser.MaritaSutes = model.MaritaSutes;
            _currentUser.Address = model.Address;
            _currentUser.Summary = model.Summary;
            _currentUser.FacebookUrl = model.FacebookUrl;
            _currentUser.LinkinUrl = model.LinkinUrl;
            db.SaveChanges();
            return RedirectToAction("EditAbout");
        }

        [HttpGet]
        public ActionResult EditEducation()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult EditEducation(ApplicationUser model)
        {
            return View();
        }

        public ActionResult Certification()
        {
            string userId = User.Identity.GetUserId();

            List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            return View(cert);
        }
        // GET: Certification/Create
        [HttpGet]
        public ActionResult CreateCertification()
        {
            string userId = User.Identity.GetUserId();
            List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            ViewBag.allCertification = cert;
            return View();
        }
        // POST: Certification/Create
        [HttpPost]
        public ActionResult CreateCertification([Bind(Exclude ="Cerid")] Certification cert)
        {
            try
            {
                cert.userid= User.Identity.GetUserId();
                db.Certification.Add(cert);
                db.SaveChanges();
                return RedirectToAction("Certification");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditCertification(int id)
        {
       
            string userId = User.Identity.GetUserId();
            List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            ViewBag.allCertification = cert;
            Certification certt = db.Certification.FirstOrDefault(a => a.Cerid == id);
            if (certt == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(certt);
            }
        }

        [HttpPost]
        public ActionResult EditCertification(int id, [Bind(Exclude = "userid,Cerid")]Certification cert)
        {

            try
            {
                Certification oldcert = db.Certification.FirstOrDefault(c => c.Cerid == id);
                if (cert == null)
                    return HttpNotFound();
                else
                {
                    oldcert.CerName = cert.CerName;
                    oldcert.CerPlace = cert.CerPlace;
                    oldcert.CerYear = cert.CerYear;
                    db.SaveChanges();


                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Certification/Delete/5
        public ActionResult DeleteCertification(int id)
        {
            Certification cert = db.Certification.FirstOrDefault(c => c.Cerid == id);
            if (cert == null)
                return HttpNotFound("Certifications Not Exists");

            return View(cert);
        }

        // POST: Certification/Delete/5
        [HttpPost]
        public ActionResult DeleteCertification(int id, FormCollection collection)
        {
            try
            {
                Certification cert = db.Certification.FirstOrDefault(c => c.Cerid == id);
                if (cert == null)
                    return HttpNotFound("Certifications Not Exists");
                db.Certification.Remove(cert);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditExperience()
        {
            return View();
        }
        ///as  admin 




        [HttpGet]
        public ActionResult matchSkill()
        {
            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName");
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title");
            return View();
        }
        [HttpPost]
        public ActionResult matchSkill([Bind(Include = "Skill_ID,JbTitle_ID")] JobTitles_Skills jobTitles_Skills)
        {
            if (ModelState.IsValid)
            {
                db.JobTitles_Skills.Add(jobTitles_Skills);
                JobTitle jobTitle = db.JobTitle.Find(jobTitles_Skills.JbTitle_ID);
                jobTitle.SkillCount++;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName", jobTitles_Skills.JbTitle_ID);
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title", jobTitles_Skills.Skill_ID);
            return View(jobTitles_Skills);
            
        }
        [HttpGet]
        public ActionResult EditSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditSkill(int id)
        {
            return View();
        }
    }



  

}