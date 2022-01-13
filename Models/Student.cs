using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Student
    {
        public string ID { get; set; }
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
