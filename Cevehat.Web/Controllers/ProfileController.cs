using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult EditAbout()
        {
            return View();
        }

        public ActionResult EditEducation()
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