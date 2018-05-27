using Cevehat.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Cevehat.Web.Models
{
    public class JobTitles_Skills
    {
        public Skill Skill { get; set; }
        public JobTitle JobTitle { get; set; }
        public int Skill_ID { get; set; }
        public int JbTitle_ID { get; set; }
        //public int Pers { get; set; }

    }
}