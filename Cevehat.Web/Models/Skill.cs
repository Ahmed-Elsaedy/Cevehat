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
        public virtual List<JobTitles_Skills> JobTitles_Skills { get; set; }
        public virtual List<User_Skills> Users { get; set; }

    }
}