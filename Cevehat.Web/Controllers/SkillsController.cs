
using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class SkillsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Skills
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Skill> Sk = db.Skill.Where(a => a.UserId == userId).ToList<Skill>();
            //List<Skill> skills = db.Skill.ToList<Skill>();
            return View(Sk);
        }

        // GET: Skills/Details/5
        public ActionResult Details(int id)
        {
            Skill b = db.Skill.FirstOrDefault(a => a.Skill_Id == id);
          
            return View(b);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            string userIDD = User.Identity.GetUserId();
            List<Skill> SK = db.Skill.Where(a => a.UserId == userIDD).ToList<Skill>();
            ViewBag.allSkills = SK;
            //List<JobTitles_Skills> JobTitles_Skills = db.JobTitles_Skills.ToList<JobTitles_Skills>();
            //SelectList JobTitlesSkills = new SelectList(JobTitles_Skills, "JbTitle_ID", "JobName");
            //ViewBag.JbTitle_ID = JobTitlesSkills;
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Skill_Id")]Skill sk)
        {
            try
            {
                // TODO: Add insert logic here
                sk.UserId = User.Identity.GetUserId();
                db.Skill.Add(sk);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            string useridd = User.Identity.GetUserId();
            List<Skill> SK = db.Skill.Where(a => a.UserId == useridd).ToList<Skill>();
            ViewBag.allSkills = SK;
            Skill sk = db.Skill.FirstOrDefault(s => s.Skill_Id == id);
            if(sk==null)
            {
                return HttpNotFound("this skill Not Found");
            }
            else {
               // List<job>
                return View(sk);


            }
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Skill sk)
        {
            try
            {
                // TODO: Add update logic here
                Skill oldskill = db.Skill.FirstOrDefault(s => s.Skill_Id == id);
                if(oldskill==null)
                {
                    return HttpNotFound("this skill not found");

                }
                else
                {
                    oldskill.Title = sk.Title;
                    oldskill.Description= sk.Description;
                    oldskill.JobTitles_Skills = sk.JobTitles_Skills;
                    db.SaveChanges();
                    return RedirectToAction("Create");

                } 
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int id)
        {
            Skill b = db.Skill.FirstOrDefault(a => a.Skill_Id == id);
            if (b == null)
                return HttpNotFound("Skill does not exist");
        
            return View(b);
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Skill b = db.Skill.FirstOrDefault(a => a.Skill_Id == id);
                if (b == null)
                    return HttpNotFound("Skill does not exist");
                db.Skill.Remove(b);
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
