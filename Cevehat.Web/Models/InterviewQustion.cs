using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class InterviewQustion
    {
        [Key]
        public int QID { get; set; }
        public string Qbody { get; set; }
        public string QAns { get; set; }
        [ForeignKey("JobTitle")]
        public int jobTitleID { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}