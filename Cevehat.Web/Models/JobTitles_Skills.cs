using Cevehat.Web.Models;
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
        public Skill Skill { get; set; }
        public JobTitle JobTitle { get; set; }

        [ForeignKey("Skill"), Key, Column(Order = 0)]
        public int Skill_ID { get; set; }
        [ForeignKey("JobTitle"), Key, Column(Order = 1)]
        public int JbTitle_ID { get; set; }
        //public int Pers { get; set; }

    }
}