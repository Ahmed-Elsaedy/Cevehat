using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Mvc.Models
{
    public class Experince
    {
        public int ExpId { get; set; }
        public string place { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string position { get; set; }
        public string responsbilty { get; set; }
        public int userID { get; set; }

    }
}