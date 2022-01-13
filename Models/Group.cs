using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Group
    {
        public string ID { get; set; }
        public int CourseID { get; set; }
        public int Number { get; set; }
        public DateTime StartYear { get; set; }
        public string Specialization { get; set; }

        public Educator Educator { get; set; }
        public Course Course { get; set; }
        public string FullNameID { get; set; }
    }
}
