using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Skill
    {
        [Key]
        public int Skill_Id { get; set; }
        public string Skill_name { get; set; }
        public virtual Lazy<List<JobTitles_Skills>> JobTitles_Skills { get; set; }
        //public List<Study_Links> Study_Links { get; set; }
    }

    //public class Study_Links
    //{
    //    public int SL_id { get; set; }
    //    public string link { get; set; }
    //    public int Skill_Id { get; set; }
    //    public Skill skil { get; set; }
    //}
}