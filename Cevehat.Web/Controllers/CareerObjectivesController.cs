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
    public class CareerObjectivesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CareerObjectives
        public ActionResult Index()
        {
            var careerObjective = db.CareerObjective.Include(c => c.JobTitle);
            return View(careerObjective.ToList());
        }

        // GET: CareerObjectives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerObjective careerObjective = db.CareerObjective.Find(id);
            if (careerObjective == null)
            {
                return HttpNotFound();
            }
            return View(careerObjective);
        }

        // GET: CareerObjectives/Create
        public ActionResult Create()
        {
            ViewBag.JobID = new SelectList(db.JobTitle, "JobId", "JobName");
            return View();
        }

        // POST: CareerObjectives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CareerId,CareerText,JobID")] CareerObjective careerObjective)
        {
            if (ModelState.IsValid)
            {
                db.CareerObjective.Add(careerObjective);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobID = new SelectList(db.JobTitle, "JobId", "JobName", careerObjective.JobID);
            return View(careerObjective);
        }

        // GET: CareerObjectives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerObjective careerObjective = db.CareerObjective.Find(id);
            if (careerObjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobID = new SelectList(db.JobTitle, "JobId", "JobName", careerObjective.JobID);
            return View(careerObjective);
        }

        // POST: CareerObjectives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CareerId,CareerText,JobID")] CareerObjective careerObjective)
        {
            if (ModelState.IsValid)
            {
                db.Entry(careerObjective).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobID = new SelectList(db.JobTitle, "JobId", "JobName", careerObjective.JobID);
            return View(careerObjective);
        }

        // GET: CareerObjectives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerObjective careerObjective = db.CareerObjective.Find(id);
            if (careerObjective == null)
            {
                return HttpNotFound();
            }
            return View(careerObjective);
        }

        // POST: CareerObjectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CareerObjective careerObjective = db.CareerObjective.Find(id);
            db.CareerObjective.Remove(careerObjective);
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
