using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class ExploreController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Explore/SearchByJobTitle
        [HttpGet]
        public ActionResult SearchByJobTitle()
        {
            List<JobTitle> JobTitles = db.JobTitle.ToList<JobTitle>();
            return View(JobTitles);
        }

        // GET: Explore/SearchBySkills
        //[HttpGet]
        //public ActionResult SearchBySkills()
        //{
        //    List<ChSkills> AllSkills = new List<ChSkills>();
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        string userid = User.Identity.GetUserId();
        //        foreach (Skill skill in db.Skill.ToList())
        //        {
        //            User_Skills usskill = (from uskills in db.User_Skills
        //                                   where uskills.SkillID == skill.Skill_Id
        //                                   && uskills.UserId == userid
        //                                   select uskills).FirstOrDefault();

        //            bool skillExists = usskill != null;
        //            AllSkills.Add(new ChSkills() { skill = skill, ischeckd = skillExists });
        //        }
        //    }
        //    else
        //        foreach (Skill skill in db.Skill.ToList())
        //        {
        //            AllSkills.Add(new ChSkills() { skill = skill, ischeckd = false });
        //        }

        //    return View(AllSkills);
        //}

        [HttpGet]
        public ActionResult SearchBySkills(List<Skill> CheckedSkills)
        {
            ApplicationUser existsuser = db.Users.Find(User.Identity.GetUserId());
            List<TitlePer> AllTitlesToFit = new List<TitlePer>();
            List<Skill> userskills = existsuser.TecSkills;
            List<JobTitle> jobtitles = (from titles in db.JobTitle
                                        where titles.JobTitles_Skills.Count > 0
                                        select titles).ToList();
            //, (from titleskill in db.JobTitles_Skills
            //   where userskills.Contains(titleskill.skill)
            //   select titleskill).Count() / titles.JobTitles_Skills.Count
            foreach (JobTitle Title in jobtitles)
            {
                int titleCount = (from titleskill in db.JobTitles_Skills
                                where userskills.Contains(titleskill.skill)
                                select titleskill).Count();

                decimal Pers = titleCount/Title.SkillCount ;
                AllTitlesToFit.Add(new TitlePer() { JobTitle = Title, per= Pers });
            }

            return View(AllTitlesToFit);
        }
    }

    public class TitlePer
    {
        public JobTitle JobTitle { get; set; }
        public decimal per { get; set; }

    }

    //public class ChSkills
    //{
    //    public Skill skill { get; set; }
    //    public bool ischeckd { get; set; }
    //}
}