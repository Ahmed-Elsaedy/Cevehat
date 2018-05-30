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
        public ActionResult Index()
        {
            

            return View();
        }
        [HttpGet]
        public ActionResult GetSkillsJobTitle()
        {
            List<JobTitle> JobTitles = db.JobTitle.ToList<JobTitle>();
            SelectList JobNameList = new SelectList(JobTitles, "JobId","JobName");
            ViewBag.JobID = JobNameList; 
            //List<JobTitle> JobTitle = db.JobTitle.ToList<JobTitle>();
            //SelectList jobtitle = new SelectList(JobTitle, "JbTitle_ID", "JobName");
            //ViewBag.JbTitle_ID = jobtitle;
            //return View(JobTitles);
            return View();
        }

        [HttpPost]
        public ActionResult etSkillsJobTitle( Skills sk)
        {
            List<Skills> skill = db.Skills.ToList<Skills>();
            db.Skill.Add(sk);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}