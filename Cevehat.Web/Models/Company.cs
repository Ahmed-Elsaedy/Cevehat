using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebSite { get; set; }
        public virtual List<JobVacancie> JobVacancies { get; set; }

    }
}