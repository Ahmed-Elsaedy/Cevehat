
using Cevehat.Web.Models;
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
            List<Skill> skills = db.Skill.ToList<Skill>();
            return View(skills);
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
                db.Skill.Add(sk);
                db.SaveChanges();
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            Skill sk = db.Skill.FirstOrDefault(s => s.Skill_Id == id);
            if(sk==null)
            {
                return HttpNotFound("this skill Not Fount");
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
                    return HttpNotFound("this skill not fount");

                }
                else
                {
                    oldskill.Title = sk.Title;
                    db.SaveChanges();
                    return RedirectToAction("Index");

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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
