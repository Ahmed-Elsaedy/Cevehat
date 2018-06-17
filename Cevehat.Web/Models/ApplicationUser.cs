using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public partial class ApplicationUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }

        public string Address { get; set; }
        public string Summary { get; set; }

        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkinUrl { get; set; }

        public DateTime? BirthDate { get; set; }
        public byte[] UserImage { get; set; }

        public MaritalStutes MaritaSutes { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public Gender Gender { get; set; }
        public virtual List<Skill> TecSkills { get; set; }
        public virtual List<Certification> Certifications { get; set; }
        public virtual List<Experince> Experinces { get; set; }
        public virtual List<Education> Educations { get; set; }
        public virtual List<User_Skills> User_TecSkills { get; set; }
        [ForeignKey("Company")]
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }

    }

    public enum MaritalStutes
    {
        Single,
        Married,
        Engaged
    }
    public enum MilitaryStatus
    {
        NotAPPlicable,
        Exempted,
        Completed,
        Postponed
    }
    public enum Gender
    {
       Male,
       Female
    }
}