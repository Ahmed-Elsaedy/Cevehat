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
        public virtual Skill skill { get; set; }
        public virtual JobTitle jobTitle { get; set; }

        [ForeignKey("skill"), Key, Column(Order = 0)]
        public int Skill_ID { get; set; }
        [ForeignKey("jobTitle"), Key, Column(Order = 1)]
        public int JbTitle_ID { get; set; }
        //public int Pers { get; set; }
        public int Weight { get; set; }

    }
}