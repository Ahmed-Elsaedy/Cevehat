using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class JopSkillsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: JopSkills
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JopSkill(int id)
        {
            Skill s = db.Skill.FirstOrDefault(a => a.Skill_Id == id);
            List<JobTitle> JopTitles = db.JobTitle.ToList<JobTitle>();
            SelectList JpTitle1 = new SelectList(db.JobTitle.ToList<JobTitle>(),"JobId","JobName",s.Skill_Id);
            ViewBag.Jobtitle_ID=JpTitle1;
            return View();
        }
    }
}




