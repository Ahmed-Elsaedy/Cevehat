using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class SkillsJobTitleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SkillsJobTitle

        [HttpGet]
        public ActionResult Index()
        {
            List<JobTitle> JobTitles = db.JobTitle.ToList<JobTitle>();
            return View(JobTitles);
        }

        //public ActionResult GetSkillsJobTitle()
        //{
        //    //List<JobTitle> JobTitle = db.JobTitle.ToList<JobTitle>();
        //    //SelectList jobtitle = new SelectList(JobTitle, "JbTitle_ID", "JobName");
        //    //ViewBag.JbTitle_ID = jobtitle;
        //    //return View(JobTitles);
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(int Id)
        //{
        //    List<JobTitle> JobTitles = db.JobTitle.ToList<JobTitle>();
        //    return View("GetSkills");
        //}

        [HttpPost]
        public ActionResult GetSkills(int Id)
        {

            db.JobTitles_Skills.Where(x => x.JbTitle_ID == Id);

            List<Skills> skills = (from x in db.JobTitles_Skills
                                      where x.JbTitle_ID == Id
                                      select x.skill).ToList();
            return View(skills);
        }


        public ActionResult GetJobTitles(int id)
        {
            JobTitle jbTitle = db.JobTitle.FirstOrDefault(a => a.JobId == id);
            return View(jbTitle);

        }
    }
}