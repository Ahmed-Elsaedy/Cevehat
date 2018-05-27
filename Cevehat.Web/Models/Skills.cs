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
        [ForeignKey("JobTitle")]
        public int JobTitle_ID { get; set; }
        public JobTitle JobTitle { get; set; }
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