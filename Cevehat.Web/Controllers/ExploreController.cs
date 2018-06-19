using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

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

        public ActionResult DownloadCV()
        {
            string UserId = User.Identity.GetUserId();

           
            List<Certification> certifications = db.Certification.Where(a => a.userid == UserId).ToList<Certification>();
            List<Education> educations = db.Education.Where(a => a.userId == UserId).ToList<Education>();
            List<Experince> experinces = db.Experinces.Where(e => e.UserID == UserId).ToList<Experince>();
            List<User_Skills> user_Skills = db.User_Skills.Where(u => u.UserId == UserId).ToList<User_Skills>();


            ReportDocument mycv = new ReportDocument();
            mycv.Load(Path.Combine(Server.MapPath("~/Report"), "CeV.rpt"));
            //mycv.SetDataSource(certifications);
            //mycv.SetDataSource(educations);
            mycv.Database.Tables[0].SetDataSource(certifications);
            var x = educations.Select(i => new { DepartmentName=i.DepartmentName}).ToList();
            mycv.Database.Tables[1].SetDataSource(x);
            //mycv.Database.Tables[2].SetDataSource(experinces);
            //mycv.Database.Tables[3].SetDataSource(user_Skills);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = mycv.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "cv.pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Explore/SearchBySkills
        [Authorize(Roles = "Employee")]
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
                        userTotalweight += ((decimal)user_Skills.Weight / 10) * ((decimal)jobskill.Weight / TitleTotalWeight)*100;
                    }
                }
                List<Skill> RemaingSkills = (from titleskills in Title.JobTitles_Skills
                                             where !listSkillsIds.Contains(titleskills.skill.Skill_Id)
                                             select titleskills.skill).ToList();
                AllTitlesToFit.Add(new TitlePer() { JobTitle = Title, per = Math.Round(userTotalweight, 2), RemaingSkills = RemaingSkills });
            }
            AllTitlesToFit = AllTitlesToFit.Where(z => z.per > 0).OrderBy(x => x.RemaingSkills.Count).OrderByDescending(y => y.per).ToList();
            ViewBag.user = existsuser;
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