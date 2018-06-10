using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class AutoCompleteController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AutoComplete
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(int id)
        //{
        //    Skill sk= db.Skill.FirstOrDefault(a => a.Skill_Id == id);
        //    return View(sk);
        //}

        public JsonResult GetAutoCompleteSkillTitle(string search)
        {
         
            List<SKILLNAME> allsearch = db.Skill.Where(x => x.Title.Contains(search)).Select(x => new SKILLNAME
            {
                Id = x.Skill_Id,
                Name = x.Title
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public class SKILLNAME
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
            }
        }