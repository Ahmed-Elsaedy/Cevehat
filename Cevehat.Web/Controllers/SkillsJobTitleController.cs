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

        public ActionResult GetJobTitlesSkill()
        {
            List<Skills> skills = db.Skill.ToList<Skills>();
            SelectList SkillsList = new SelectList(skills, "Skill_Id","Skill_name");
            ViewBag.SkillId = SkillsList;
            return View();
        }

        public ActionResult GetSkills(int id)
        {
            Skills skill = db.Skill.FirstOrDefault(a => a.Skill_Id == id);

            return View(skill);
           
        }


        public ActionResult GetJobTitles(int id)
        {
            JobTitle jbTitle = db.JobTitle.FirstOrDefault(a => a.JobId == id);
            return View(jbTitle);
         
        }
    }
}