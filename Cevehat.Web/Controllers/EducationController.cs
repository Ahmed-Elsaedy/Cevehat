using Cevehat.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

namespace Cevehat.Web.Controllers
{
    public class EducationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Education
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Education> educations = db.Education.Where(a => a.userId == userId).ToList<Education>();

            return View(educations);
        }

        // GET: Education/Details/5
        public ActionResult Details(int id)
        {
            Education ed = db.Education.FirstOrDefault(a => a.EducationId == id);

            return View(ed);
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            List<Education> educations = db.Education.Where(a => a.userId == userId).ToList<Education>();
            ViewBag.allEducations = educations;
            return View();
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "EducationId")]Education education)
        {
            try
            {
                education.userId = User.Identity.GetUserId();
                db.Education.Add(education);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            string userId = User.Identity.GetUserId();
            List<Education> educations = db.Education.Where(a => a.userId == userId).ToList<Education>();
            ViewBag.allEducations = educations;
            Education ed = db.Education.FirstOrDefault(e => e.EducationId == id);
            if (ed == null)
            { return HttpNotFound(); }
            else
            {
                return View(ed);
            }
        }

        // POST: Education/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Education education)
        {
            try
            {
                // TODO: Add update logic here
                Education old_ed = db.Education.FirstOrDefault(e => e.EducationId == id);
                if (old_ed == null)
                {
                    return HttpNotFound("this trying not fount");

                }
                else
                {


                    old_ed.GPA = education.GPA;
                    old_ed.GradYear = education.GradYear;
                    old_ed.OrganizationName = education.OrganizationName;
                    old_ed.DepartmentName = education.DepartmentName;
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }

            catch
            {
                return View();
            }
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int id)
        {
            Education ed = db.Education.FirstOrDefault(a => a.EducationId == id);
            if (ed == null)
                return HttpNotFound("Education  not exist");
            return View(ed);
        }

        // POST: Education/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                Education ed = db.Education.FirstOrDefault(a => a.EducationId == id);
                if (ed == null)
                    return HttpNotFound("education  not exist");
                db.Education.Remove(ed);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
