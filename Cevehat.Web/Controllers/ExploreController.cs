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
        [HttpGet]
        public ActionResult SearchBySkills()
        {
            ApplicationUser existsuser = db.Users.Find(User.Identity.GetUserId());
            List<TitlePer> AllTitlesToFit = new List<TitlePer>();
            List<Skill> usertecskills = existsuser.TecSkills;
            var listSkillsIds = usertecskills.Select(x => x.Skill_Id).ToList();
            List<JobTitle> jobtitles = (from titles in db.JobTitle
                                        where titles.SkillCount > 0
                                        select titles).ToList();
            foreach (JobTitle Title in jobtitles)
            {
                decimal TitleTotalWeight = Title.JobTitles_Skills.Sum(x => x.Weight);
                decimal userTotalweight = 0;
                foreach (JobTitles_Skills jobskill in Title.JobTitles_Skills)
                {
                    User_Skills user_Skills = db.User_Skills.Where(x => x.SkillID == jobskill.Skill_ID && x.UserId == existsuser.Id).FirstOrDefault();
                    if (listSkillsIds.Contains(jobskill.skill.Skill_Id))
                    {
                        userTotalweight += ((decimal)user_Skills.Weight / 10) * ((decimal)jobskill.Weight / 10)*100;
                    }
                }
                List<Skill> RemaingSkills = (from titleskills in Title.JobTitles_Skills
                                             where !listSkillsIds.Contains(titleskills.skill.Skill_Id)
                                             select titleskills.skill).ToList();
                AllTitlesToFit.Add(new TitlePer() { JobTitle = Title, per = Math.Round(userTotalweight, 2), RemaingSkills = RemaingSkills });
            }
            AllTitlesToFit = AllTitlesToFit.OrderBy(x => x.RemaingSkills.Count).OrderByDescending(y => y.per).ToList();
            return View(AllTitlesToFit);
        }
    }
    public class TitlePer
    {
        public JobTitle JobTitle { get; set; }
        public decimal per { get; set; }
        public List<Skill> RemaingSkills { get; set; }

    }
}