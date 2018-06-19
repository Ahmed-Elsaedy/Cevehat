using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Cevehat.Web.Controllers
{
    public partial class DefaultController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Default
        public ActionResult Index()
        {
            var companies = db.Company.Count();
            ViewBag.companiesCount = companies;
            var allJobVacancies = db.JobVacancie.Count();
            ViewBag.allJobVacanciesCount = allJobVacancies;
            var activeJobVacancies = db.JobVacancie.Where(a => a.State == State.Active).Count();
            ViewBag.activeJobVacanciesCount = activeJobVacancies;
            var users = db.Users.Where(a => a.CompanyID == 0).Count();
            ViewBag.usersCount = users;
            List<JobVacancie> activeJobVacanciesList = db.JobVacancie.Where(a => a.State == State.Active).Take(10).ToList();
            ViewBag.activeJobVacanciesList = activeJobVacanciesList;
            List<Company> AllCompaniesLogo = db.Company.ToList();
            ViewBag.AllCompaniesLogo = AllCompaniesLogo;
            return View();
        }




    }
}