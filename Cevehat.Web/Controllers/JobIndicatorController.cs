using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class JobIndicatorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: JobIndicator
        public ActionResult Index()
        {
            List<TopJobTitles> qurRes = db.JobVacancie.ToList<JobVacancie>().GroupBy(x => x.JobTitle).OrderByDescending(z => z.Count()).Select(y => new TopJobTitles() { JobTitle = y.Key, count = y.Count() }).Take(3).ToList<TopJobTitles>();
            ViewBag.qurRes = qurRes;
            return View();
        }
    }
    public class TopJobTitles
    {
        public int count { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}