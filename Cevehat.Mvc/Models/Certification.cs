using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Mvc.Models
{
    public class Certification
    {
        public int id { get; set; }
        public string place { get; set; }
        public string name { get; set; }
        public DateTime year { get; set; }
        public int userid { get; set; }
    }
}