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
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual List<JobTitles_Skills> JobTitles_Skills { get; set; }
    }
}