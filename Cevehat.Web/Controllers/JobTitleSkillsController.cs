using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class JobTitleSkillsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: JobTitleSkills
        public ActionResult Index()
        {
            List<Skills> skils = db.Skill.ToList<Skills>();
            //IEnumerable<SelectListItem> skills = new IEnumerable<SelectListItem>() ;
            foreach (var item in skils)
            {

            }
            IEnumerable<SelectListItem> jobTitle = new SelectList(db.JobTitle.ToList<JobTitle>(), "JobId", "JobName");
            //ViewData.Add("skills" ,skills);
            ViewBag.jobTitles = jobTitle;
            List<JobTitles_Skills> jobTitles_Skills = db.JobTitles_Skills.ToList<JobTitles_Skills>();
            return View(jobTitles_Skills);
        }

        // GET: JobTitleSkills/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobTitleSkills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTitleSkills/Create
        [HttpPost]
        public ActionResult Create(JobTitles_Skills jobTitles_Skills)
        {
            try
            {
                db.JobTitles_Skills.Add(jobTitles_Skills);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobTitleSkills/Edit/5
        public ActionResult Edit(int id)
        {
             db.JobTitles_Skills.Find(id);

            return View();
        }

        // POST: JobTitleSkills/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobTitleSkills/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobTitleSkills/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
