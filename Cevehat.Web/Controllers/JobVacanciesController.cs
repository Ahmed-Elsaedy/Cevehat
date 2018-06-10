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
    public class JobVacanciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobVacancies
        public ActionResult Index()
        {
            var jobVacancie = db.JobVacancie.Include(j => j.Company).Include(j => j.JobTitle);
            return View(jobVacancie.ToList());
        }

        // GET: JobVacancies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVacancie jobVacancie = db.JobVacancie.Find(id);
            if (jobVacancie == null)
            {
                return HttpNotFound();
            }
            return View(jobVacancie);
        }

        // GET: JobVacancies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyName");
            ViewBag.JobTitleID = new SelectList(db.JobTitle, "JobId", "JobName");
            return View();
        }

        // POST: JobVacancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobVacancieID,ExpYears,JobTitleID,CompanyID,JobType")] JobVacancie jobVacancie)
        {
            if (ModelState.IsValid)
            {
                jobVacancie.State = State.Active;
                jobVacancie.Date = DateTime.Now;
                db.JobVacancie.Add(jobVacancie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyName", jobVacancie.CompanyID);
            ViewBag.JobTitleID = new SelectList(db.JobTitle, "JobId", "JobName", jobVacancie.JobTitleID);
            return View(jobVacancie);
        }

        // GET: JobVacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVacancie jobVacancie = db.JobVacancie.Find(id);
            if (jobVacancie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyName", jobVacancie.CompanyID);
            ViewBag.JobTitleID = new SelectList(db.JobTitle, "JobId", "JobName", jobVacancie.JobTitleID);
            return View(jobVacancie);
        }

        // POST: JobVacancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobVacancieID,ExpYears,JobTitleID,CompanyID,JobType")] JobVacancie jobVacancie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobVacancie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyName", jobVacancie.CompanyID);
            ViewBag.JobTitleID = new SelectList(db.JobTitle, "JobId", "JobName", jobVacancie.JobTitleID);
            return View(jobVacancie);
        }

        // GET: JobVacancies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVacancie jobVacancie = db.JobVacancie.Find(id);
            if (jobVacancie == null)
            {
                return HttpNotFound();
            }
            return View(jobVacancie);
        }

        // POST: JobVacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobVacancie jobVacancie = db.JobVacancie.Find(id);
            jobVacancie.State = State.Closed;
            //db.JobVacancie.Remove(jobVacancie);
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
