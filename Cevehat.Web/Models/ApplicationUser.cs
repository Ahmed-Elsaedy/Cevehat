using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public partial class ApplicationUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime BirthDate { get; set; }
        public MaritalStutes MaritaSutes { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public bool Gender { get; set; }
        public virtual List<Skill> TecSkills { get; set; }
        public virtual List<SoftSkill> SoftSkills { get; set; }
        public virtual List<Certification> Certifications { get; set; }
        public virtual List<Experince> Experinces { get; set; }
        public virtual List<Education> Educations { get; set; }
        
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
}