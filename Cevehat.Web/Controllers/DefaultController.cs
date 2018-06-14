using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cevehat.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult CompanyProfile()
        {
            return View();
        }
    }
}