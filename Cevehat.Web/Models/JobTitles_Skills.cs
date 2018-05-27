using Cevehat.web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Cevehat.Web.Models
{
    public class JobTitles_Skills
    {
        [Key]
        public int JobTitles_Skills_ID { get; set; }
        public Skill Skill { get; set; }
        public JobTitle JobTitle { get; set; }
        [ForeignKey("Skill")]
        public int Skill_ID { get; set; }
        [ForeignKey("JobTitle")]
        public int JbTitle_ID { get; set; }
        //public int Pers { get; set; }

    }
}