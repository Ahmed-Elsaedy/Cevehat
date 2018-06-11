using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class JobVacancie
    {
        [Key]
        public int JobVacancieID { get; set; }
        public int ExpYears { get; set; }
        [ForeignKey("JobTitle")]
        public int JobTitleID { get; set; }
        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }
        public virtual Company Company { get; set; }
        public JobType JobType { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual List<JobRequirements> JobRequirements { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public virtual List<ApplayedUsers> ApplayedUsers { get; set; }
    }

    public class ApplayedUsers
    {
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public AppliedUserState AppliedUserState { get; set; }

    }

    public class JobRequirements
    {
        [Key]
        public int ReqID { get; set; }
        public string ReqText { get; set; }
        [ForeignKey("JobVacancie")]
        public int JobVacID { get; set; }
        public virtual JobVacancie JobVacancie { get; set; }
    }

    public enum State
    {
        Active,
        Closed
    }
    public enum AppliedUserState
    {
        Applied,
        Shortlisted,
        w8ing_for_intervew,
        Rejected,
        Accepted
    }

    public enum JobType
    {
        FullTime,
        PartTime
    }
}