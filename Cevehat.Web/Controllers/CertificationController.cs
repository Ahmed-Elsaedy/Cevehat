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
        ApplicationDbContext db = new ApplicationDbContext();

        public CertificationController()
        {
             
        }
        // GET: Certification
        public ActionResult Index()
        {
            
            List<Certification> certifications = db.Certification.ToList<Certification>();

            ApplicationDbContext db = new ApplicationDbContext();
            string userId = User.Identity.GetUserId();
            ApplicationUser newUser = db.Users.Where(a => a.Id == userId).FirstOrDefault();

            return PartialView(newUser);

            //List<Certification> certifications = db.Certification.ToList<Certification>();

            //return View(certifications);
        }

        // GET: Certification/Details/5
        public ActionResult Details(int id)
        {
            Certification cert = db.Certification.FirstOrDefault(a=>a.Cerid==id);

            return View(cert);
        }

        // GET: Certification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certification/Create
        [HttpPost]
        public ActionResult Create(Certification cert)
        {
            try
            {
            
                db.Certification.Add(cert);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Certification/Edit/5
        public ActionResult Edit(int id)
        {
            Certification cert = db.Certification.FirstOrDefault(c => c.Cerid == id);
            return View(cert);
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


                    return RedirectToAction("Index");
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
                return HttpNotFound();

            return View(cert);
        }

        // POST: Certification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Certification cert = db.Certification.FirstOrDefault(c => c.Cerid == id);
                db.Certification.Remove(cert);
                db.SaveChanges();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
