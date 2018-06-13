using Cevehat.Web.Models;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class AboutController : Controller
    {
        //create object of db context
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AllData()
        {
            string UserId = User.Identity.GetUserId();
            //ApplicationUser _currentuser = db.Users.Where(a => a.Id == userid).FirstOrDefault();
            List<Certification> certifications = db.Certification.Where(a => a.userid == UserId).ToList<Certification>();
            List<Education> educations = db.Education.Where(a => a.userId == UserId).ToList<Education>();
            dynamic model = new ExpandoObject();
            model.Certification = certifications;
            model.Education = educations;
            return View();
        }
        public ActionResult DownloadCV()
        {
            string UserId = User.Identity.GetUserId();
            //ApplicationUser _currentuser = db.Users.Where(a => a.Id == userid).FirstOrDefault();
            List<Certification> certifications = db.Certification.Where(a => a.userid == UserId).ToList<Certification>();
            List<Education> educations = db.Education.Where(a => a.userId == UserId).ToList<Education>();
            //dynamic model = new ExpandoObject();
            //model.Certification = certifications;
            //model.Education = educations;
            ReportDocument mycv = new ReportDocument();
            mycv.Load(Path.Combine(Server.MapPath("~/Report"), "CV.rpt"));
            mycv.SetDataSource(certifications);
            mycv.SetDataSource(educations);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = mycv.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "cv.pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
        // GET: About
        [Authorize]
        public ActionResult Index()
        {
            

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

        public ActionResult SaveAboutUs(ApplicationUser model)
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
            return RedirectToAction("Index");
        }
    }
}