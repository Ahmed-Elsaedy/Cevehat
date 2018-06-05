using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;

namespace Cevehat.Web.Controllers
{
    public class User_SkillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User_Skills
        public ActionResult Index()
        {
            var user_Skills = db.User_Skills.Include(u => u.Skill).Include(u => u.User);
            return View(user_Skills.ToList());
        }

        // GET: User_Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Skills user_Skills = db.User_Skills.Find(id);
            if (user_Skills == null)
            {
                return HttpNotFound();
            }
            return View(user_Skills);
        }

        // GET: User_Skills/Create
        public ActionResult Create()
        {
            ViewBag.SkillID = new SelectList(db.Skill, "Skill_Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Fname");
            return View();
        }

        // POST: User_Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Skills_ID,UserId,SkillID")] User_Skills user_Skills)
        {
            user_Skills.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.User_Skills.Add(user_Skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillID = new SelectList(db.Skill, "Skill_Id", "Title", user_Skills.SkillID);
            
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", user_Skills.UserId);
            return View(user_Skills);
        }

        // GET: User_Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Skills user_Skills = db.User_Skills.Find(id);
            if (user_Skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillID = new SelectList(db.Skill, "Skill_Id", "Title", user_Skills.SkillID);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", user_Skills.UserId);
            return View(user_Skills);
        }

        // POST: User_Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Skills_ID,UserId,SkillID")] User_Skills user_Skills)
        {
            user_Skills.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Entry(user_Skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillID = new SelectList(db.Skill, "Skill_Id", "Title", user_Skills.SkillID);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Fname", user_Skills.UserId);
            return View(user_Skills);
        }

        // GET: User_Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Skills user_Skills = db.User_Skills.Find(id);
            if (user_Skills == null)
            {
                return HttpNotFound();
            }
            return View(user_Skills);
        }

        // POST: User_Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Skills user_Skills = db.User_Skills.Find(id);
            db.User_Skills.Remove(user_Skills);
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
