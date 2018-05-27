using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class SoftSkill
    {
        [Key]
        public int SoftSkillsID { get; set; }
        public string Name { get; set; }
        [ForeignKey("ApplicationUser")]
        public string userid { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}