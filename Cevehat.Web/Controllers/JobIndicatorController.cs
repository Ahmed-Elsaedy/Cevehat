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
            List<JobVacancie> jobVacancies = db.JobVacancie.ToList<JobVacancie>();

            //var qurRes =  (from vac in jobVacancies
            //group vac by vac.JobTitleID into g
            //select g).ToList<JobVacancie>().OrderBy(x=> x.JobTitleID)  ;

            List<res> qurRes = jobVacancies.GroupBy(x => x.JobTitle).OrderByDescending(z => z.Count()).Select(y => new res() { JobTitle = y.Key, count = y.Count() }).Take(2).ToList<res>();
            ViewBag.qurRes = qurRes;
            //qurRes[0].jobtitle.JobName
            return View();
        }


    }
    public class res
    {
        public int count { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}