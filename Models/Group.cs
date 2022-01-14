using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Group
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int StartYear { get; set; }
        public string specialization { get; set; }
        public string Educator { get; set; }
        public int Course { get; set; }


        public Course CourseID { get; set; }


        public ICollection<Student> Students { get; set; }
        public ICollection<Educator> Educators { get; set; }
    }
}
