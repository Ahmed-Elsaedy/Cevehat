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

        [HttpPost]
        public ActionResult GetSkills(int Id)
        {
            db.JobTitles_Skills.Where(x => x.JbTitle_ID == Id);
            List<Skill> skills = (from x in db.JobTitles_Skills
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