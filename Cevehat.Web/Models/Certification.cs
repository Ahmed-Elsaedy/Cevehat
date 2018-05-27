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
        public int id { get; set; }
        public string place { get; set; }
        public string name { get; set; }
        public DateTime year { get; set; }
        [ForeignKey("ApplicationUser")]
        public int userid { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}