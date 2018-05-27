using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.Mvc.Models
{
    public class InterviewQustion
    {
        public int QID { get; set; }
        public string Qbody { get; set; }
        public string QAns { get; set; }
        public int jobTitleID { get; set; }

    }
}