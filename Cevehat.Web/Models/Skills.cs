using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Mvc.Models
{
    public class Skill
    {
        public int Skill_Id { get; set; }
        public string Skill_name { get; set; }
        public List<Study_Links> study_Links { get; set; }
    }

    public class Study_Links
    {
        public int SL_id { get; set; }
        public string link { get; set; }
        public int Skill_Id { get; set; }
        public Skill skil { get; set; }

    }
}