using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cevehat.Web.Models;
using Microsoft.AspNet.Identity;

namespace Cevehat.Web.Controllers
{
    public class ExperinceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experince
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<Experince> exper = db.Experinces.Where(a => a.UserID == userId).ToList<Experince>();
            return View(exper);
        }

        // GET: Experince/Details/5
        public ActionResult Details(int? id)
        {
            Experince exper = db.Experinces.FirstOrDefault(a=>a.ExpId==id);
            return View(exper);
        }

        // GET: Experince/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            List<Experince> exper = db.Experinces.Where(a => a.UserID == userId).ToList<Experince>();
            ViewBag.allExperience = exper;
            return View();
        }

        // POST: Experince/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ExpId")] Experince experince)
        {
            try
            {
                experince.UserID = User.Identity.GetUserId();
                db.Experinces.Add(experince);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experince/Edit/5
        public ActionResult Edit(int? id)
        {
            string userId = User.Identity.GetUserId();
            List<Experince> exper = db.Experinces.Where(a => a.UserID == userId).ToList<Experince>();
            ViewBag.allExperience = exper;
            Experince experr = db.Experinces.FirstOrDefault(a=>a.ExpId==id);
            if(experr==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(experr);
            }

        }

        // POST: Experince/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int id,Experince experince)
        {
        try
            {
                Experince exp = db.Experinces.FirstOrDefault(a => a.ExpId == id);
                if (exp == null)
                {
                    return HttpNotFound("this trying not fount");
                }
                else {
                    exp.Place = experince.Place;
                    exp.StartDate = experince.StartDate;
                    exp.EndDate = experince.EndDate;
                    exp.Position = experince.Position;
                    exp.Responsbilty = experince.Responsbilty;
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }
            catch
            {

                return View();
            }
        }

        // GET: Experince/Delete/5
        public ActionResult Delete(int id)
        {
            Experince exp = db.Experinces.FirstOrDefault(a => a.ExpId == id);
            if (exp == null)
            
                return HttpNotFound("Experience Not Exists");
                return View(exp);
            
        }
           

        // POST: Experince/Delete/5
        [HttpPost]

        public ActionResult Delete(int id,FormCollection collect)
        {
            try
            {
                Experince experince = db.Experinces.FirstOrDefault(a => a.ExpId == id);
                if (experince == null)
                    return HttpNotFound("Experience Not Exists");
                db.Experinces.Remove(experince);
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
