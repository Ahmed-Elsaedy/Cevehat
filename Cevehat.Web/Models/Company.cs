using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebSite { get; set; }
        public virtual List<JobVacancie> JobVacancies { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        

    }
}