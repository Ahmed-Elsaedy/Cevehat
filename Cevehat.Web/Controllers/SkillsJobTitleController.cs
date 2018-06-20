using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
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
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<JobTitle> JobTitles = db.JobTitle.ToList<JobTitle>();
            List<Skill> Skills = db.Skill.ToList<Skill>();
            ViewBag.Skills = Skills;
            return View(JobTitles);
        }


        //please add your view to this action 
        public ActionResult getSkillsByTitle(int Titleid)
        {
            List<Skill> skills = (from x in db.JobTitles_Skills
                                  where x.JbTitle_ID == Titleid
                                  select x.skill).ToList();
            return View(skills);
        }
        /// <summary>
        /// Get The Skills And Active Vacancies Of the JobTitle
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSkills(int Id)
        {
            List<JobVacancie> JobVacancies = (from Vacancie in db.JobVacancie
                                              where Vacancie.JobTitleID == Id && Vacancie.State == State.Active
                                              select Vacancie).ToList();
            return View(JobVacancies);
        }


        //please add your view to this action 
        public ActionResult GetTitlsBySkill(int Skillid)
        {
            List<JobTitle> jbTitles = (from x in db.JobTitles_Skills
                                       where x.Skill_ID == Skillid
                                       select x.jobTitle).ToList();
            return View(jbTitles);
        }




        public ActionResult GetJobTitles(int Id)
        {
            //Skill chSkill = db.Skill.Find(Id);
            List<JobVacancie> allvacancies = db.JobVacancie.ToList();
            List<JobVacancie> JobVacancies = new List<JobVacancie>();
            foreach (JobVacancie Vac in allvacancies)
            {
                foreach (Skill VacSkills in Vac.Skills)
                {
                    if (VacSkills.Skill_Id == Id)
                    {
                        JobVacancies.Add(Vac);
                    }
                }
            }
            return View(JobVacancies);
        }

        public ActionResult JobDit(JobVacancie Vacancie)
        {
            JobVacancie vac = db.JobVacancie.Find(Vacancie.JobVacancieID); 
            vac.Company = db.Company.Find(Vacancie.CompanyID);
            vac.JobTitle = db.JobTitle.Find(Vacancie.JobTitleID);
            bool isAppl = false;
            string userid = User.Identity.GetUserId();
            foreach (ApplayedUsers apuser in vac.ApplayedUsers)
            {
                if (apuser.UserId == userid)
                {
                    isAppl = true;
                }
            }
            ViewBag.isAppl = isAppl;
            return View(vac);
        }

        [HttpGet]
        public ActionResult ApplayToJob(int JobVacancieID)
        {
            JobVacancie applayedVac = db.JobVacancie.Find(JobVacancieID);
            applayedVac.ApplayedUsers.Add(new ApplayedUsers() { UserId = User.Identity.GetUserId(), AppliedUserState = AppliedUserState.Applied, ApplicationUser = db.Users.Find(User.Identity.GetUserId()) });
            db.SaveChanges();
            return RedirectToAction("AppliedJobs","UserProfile");
        }
    }
}