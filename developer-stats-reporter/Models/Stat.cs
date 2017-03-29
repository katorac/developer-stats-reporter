using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace developer_stats_reporter.Models
{
    public class Stat
    {
        public string Country { get; set; }
        public string Gender { get; set; }
        public string SelfIdentify { get; set; }
        public string Occupation { get; set; }
        public double Experience { get; set; }
        public decimal Salary { get; set; }
        public string TechUsing { get; set; }
        public string TechWanting { get; set; }
        public string Industry { get; set; }

    }
}