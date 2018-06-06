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
    public class JobTitles_SkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobTitles_Skills
        public ActionResult Index()
        {
            var jobTitles_Skills = db.JobTitles_Skills.Include(j => j.jobTitle).Include(j => j.skill);
            return View(jobTitles_Skills.ToList());
        }

        // GET: JobTitles_Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitles_Skills jobTitles_Skills = db.JobTitles_Skills.Find(id);
            if (jobTitles_Skills == null)
            {
                return HttpNotFound();
            }
            return View(jobTitles_Skills);
        }

        // GET: JobTitles_Skills/Create
        public ActionResult Create()
        {
            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName");
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title");
            return View();
        }

        // POST: JobTitles_Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Skill_ID,JbTitle_ID")] JobTitles_Skills jobTitles_Skills)
        {
            if (ModelState.IsValid)
            {
                db.JobTitles_Skills.Add(jobTitles_Skills);
                JobTitle jobTitle = db.JobTitle.Find(jobTitles_Skills.JbTitle_ID);
                jobTitle.Skill_Count++;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName", jobTitles_Skills.JbTitle_ID);
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title", jobTitles_Skills.Skill_ID);
            return View(jobTitles_Skills);
        }

        // GET: JobTitles_Skills/Edit/5
        public ActionResult Edit(int? Jobid, int? Skillid)
        {
            if (Skillid == null || Jobid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitles_Skills jobTitles_Skills = db.JobTitles_Skills.Where(x => x.JbTitle_ID == Jobid && x.Skill_ID == Skillid).FirstOrDefault();
            if (jobTitles_Skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName", jobTitles_Skills.JbTitle_ID);
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title", jobTitles_Skills.Skill_ID);
            return View(jobTitles_Skills);
        }

        // POST: JobTitles_Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Skill_ID,JbTitle_ID")] JobTitles_Skills jobTitles_Skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobTitles_Skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JbTitle_ID = new SelectList(db.JobTitle, "JobId", "JobName", jobTitles_Skills.JbTitle_ID);
            ViewBag.Skill_ID = new SelectList(db.Skill, "Skill_Id", "Title", jobTitles_Skills.Skill_ID);
            return View(jobTitles_Skills);
        }

        // GET: JobTitles_Skills/Delete/5
        public ActionResult Delete(int? Jobid, int? Skillid)
        {
            if (Jobid == null || Skillid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitles_Skills jobTitles_Skills = db.JobTitles_Skills.Where(js => js.JbTitle_ID == Jobid && js.Skill_ID == Skillid).FirstOrDefault();
            if (jobTitles_Skills == null)
            {
                return HttpNotFound();
            }
            return View(jobTitles_Skills);
        }

        // POST: JobTitles_Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? Jobid, int? Skillid)
        {
            if (Jobid == null || Skillid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTitles_Skills jobTitles_Skills = db.JobTitles_Skills.Where(x => x.JbTitle_ID == Jobid && x.Skill_ID == Skillid).FirstOrDefault();
            if (jobTitles_Skills == null)
            {
                return HttpNotFound();
            }
            db.JobTitles_Skills.Remove(jobTitles_Skills);
            JobTitle jobTitle = db.JobTitle.Find(jobTitles_Skills.JbTitle_ID);
            jobTitle.Skill_Count--;
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
