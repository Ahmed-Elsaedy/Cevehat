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


        /// <summary>
        /// Get The Skills And Active Vacancies Of the JobTitle
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSkills(int Id)
        {
            //db.JobTitles_Skills.Where(x => x.JbTitle_ID == Id);
            List<Skill> skills = (from x in db.JobTitles_Skills
                                  where x.JbTitle_ID == Id
                                  select x.skill).ToList();
            List<JobVacancie> JobVacancies = (from Vacancie in db.JobVacancie
                                              where Vacancie.JobTitleID == Id && Vacancie.State == State.Active
                                              select Vacancie).ToList();
            ViewBag.JobVacancies = JobVacancies;

            return View(skills);
        }
        
        public ActionResult GetJobTitles(int Id)
        {
            Skill chSkill = db.Skill.Find(Id);
            List<JobTitle> jbTitles = (from x in db.JobTitles_Skills
                                       where x.Skill_ID == Id
                                       select x.jobTitle).ToList();
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
            //List<JobVacancie> JobVacancies = (from z in db.JobVacancie
            //where z.Skills.ToList().Contains(chSkill)
            //select z).ToList();
            ViewBag.JobVacancies = JobVacancies;
            return View(jbTitles);
        }

        public ActionResult JobDit(JobVacancie Vacancie)
        {
            Vacancie.Company = db.Company.Find(Vacancie.CompanyID);
            Vacancie.JobTitle = db.JobTitle.Find(Vacancie.JobTitleID);

            return View(Vacancie);
        }

        public ActionResult ApplayToJob(int Id)
        {
            JobVacancie applayedVac = db.JobVacancie.Find(Id);
            applayedVac.ApplayedUsers.Add(new ApplayedUsers() { UserId = User.Identity.GetUserId() , AppliedUserState = AppliedUserState.Applied , ApplicationUser= db.Users.Find(User.Identity.GetUserId()) });
            return View();
        }
    }
}