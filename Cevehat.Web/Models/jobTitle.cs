using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class JobTitle
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public virtual List<CareerObjective> CareerObjectives { get; set; }
        public virtual List<InterviewQustion> InterviewQustions { get; set; }
        public virtual List<JobTitles_Skills> JobTitles_Skills { get; set; }
        public decimal SkillCount { get; set; }
    }
}