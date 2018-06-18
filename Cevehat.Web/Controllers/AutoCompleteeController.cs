using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class AutoCompleteeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AutoComplete
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAutoCompleteSkillTitle(string search)
        {

            List<SKILLNAME> allsearch = db.Skill.Where(x => x.Title.Contains(search)).Select(x => new SKILLNAME
            {
                Id = x.Skill_Id,
                Name = x.Title
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetAutoCompleteJobTitle(string search)
        {
            List<JobTitleName> allsearch = db.JobTitle.Where(x => x.JobName.Contains(search)).Select(x => new JobTitleName
            {
                Id = x.JobId,
                Name = x.JobName
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SearchByTitle(string searchTitle)
        {
            JobTitle title = (from Titls in db.JobTitle
                           where Titls.JobName == searchTitle
                           select Titls).FirstOrDefault();
            return RedirectToAction("GetSkills", "SkillsJobTitle",new { Id = title.JobId });
            //return part
        }

        public ActionResult Search(string searchInput)
        {
            Skill skill = (from skills in db.Skill
                           where skills.Title == searchInput
                           select skills).FirstOrDefault();

            return RedirectToAction("GetJobTitles", "SkillsJobTitle",new { Id = skill.Skill_Id });
        }
        public class SKILLNAME
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class JobTitleName
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}