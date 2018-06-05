using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{

    public class CertificationController : Controller
    {

       public ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: Certification
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            return View(cert);
        }

        // GET: Certification/Details/5
        public ActionResult Details(int? id)
        {
            Certification cert = db.Certification.FirstOrDefault(a => a.Cerid == id);
            return View(cert);
        }

        // GET: Certification/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            List<Certification> cert = db.Certification.Where(a => a.userid == userId).ToList<Certification>();
            ViewBag.allCertification = cert;
            return View();
        }
        // POST: Certification/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Cerid")] Certification cert)
        {
            try
            {
                cert.userid = User.Identity.GetUserId();
                db.Certification.Add(cert);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Certification/Edit/5
        public ActionResult Edit(int id)
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

        // POST: Certification/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Exclude = "userid,Cerid")]Certification cert)
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
        public ActionResult Delete(int id)
        {
            Certification cert = db.Certification.FirstOrDefault(c => c.Cerid == id);
            if (cert == null)
                return HttpNotFound("Certifications Not Exists");

            return View(cert);
        }

        // POST: Certification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
