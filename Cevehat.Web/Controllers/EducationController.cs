using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class EducationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Education
        public ActionResult Index()
        {
            List<Education> educations = db.Education.ToList<Education>();

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
            return View();
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "EducationId")]Education education)
        {
            try
            {
               
                db.Education.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            Education ed = db.Education.FirstOrDefault(e => e.EducationId == id);
            if (ed==null)
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
                    return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
