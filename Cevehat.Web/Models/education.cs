﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cevehat.web.Models
{
    public class education
    {
        
        public int educationId { get; set; }

        public decimal GPA { get; set; }

        public DateTime GradYear { get; set; }

        public string DepartmentName { get; set; }

        public string OrganizationName { get; set; }

        public int userId { get; set; }

    }
}