﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracking.Web.Models
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        // relationship with Intervantions
        public List<Survey> Surveys { get; set; }
    }
}
