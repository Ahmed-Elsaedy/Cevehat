using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Experince
    {
        [Key]
        public int ExpId { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPresent { get; set; }
        public string Position { get; set; }
        public string Responsbilty { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}