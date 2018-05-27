using Cevehat.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cevehat.Web.Models
{
    public class Certification
    {
        [Key]
        public int Cerid { get; set; }
        public string CerPlace { get; set; }
        public string CerName { get; set; }
        public DateTime CerYear { get; set; }
        [ForeignKey("ApplicationUser")]
        public string userid { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}