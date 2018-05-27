using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class CareerObjective
    {
        [Key]
        public int CareerId { get; set; }
        public string CareerText { get; set; }
        [ForeignKey("JobTitle")]
        public int JobID { get; set; }
        public JobTitle JobTitle { get; set; }

        // test
    }
}