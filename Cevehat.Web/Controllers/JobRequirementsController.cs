using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cevehat.Web.Models;

namespace Cevehat.Web.Controllers
{
    public class JobRequirementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobRequirements
        public ActionResult Index()
        {
            var jobRequirements = db.JobRequirements.Include(j => j.JobVacancie);
            return View(jobRequirements.ToList());
        }

        // GET: JobRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            return View(jobRequirements);
        }

        // GET: JobRequirements/Create
        public ActionResult Create()
        {
            ViewBag.JobVacID = new SelectList(db.JobVacancie, "JobVacancieID", "JobVacancieID");
            return View();
        }

        // POST: JobRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReqID,ReqText,JobVacID")] JobRequirements jobRequirements)
        {
            if (ModelState.IsValid)
            {
                db.JobRequirements.Add(jobRequirements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobVacID = new SelectList(db.JobVacancie, "JobVacancieID", "JobVacancieID", jobRequirements.JobVacID);
            return View(jobRequirements);
        }

        // GET: JobRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobVacID = new SelectList(db.JobVacancie, "JobVacancieID", "JobVacancieID", jobRequirements.JobVacID);
            return View(jobRequirements);
        }

        // POST: JobRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReqID,ReqText,JobVacID")] JobRequirements jobRequirements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobRequirements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobVacID = new SelectList(db.JobVacancie, "JobVacancieID", "JobVacancieID", jobRequirements.JobVacID);
            return View(jobRequirements);
        }

        // GET: JobRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            if (jobRequirements == null)
            {
                return HttpNotFound();
            }
            return View(jobRequirements);
        }

        // POST: JobRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobRequirements jobRequirements = db.JobRequirements.Find(id);
            db.JobRequirements.Remove(jobRequirements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
