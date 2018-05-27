using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }
        public decimal GPA { get; set; }
        public DateTime GradYear { get; set; }
        public string DepartmentName { get; set; }
        public string OrganizationName { get; set; }
        [ForeignKey("ApplicationUser")]
        public string userId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}