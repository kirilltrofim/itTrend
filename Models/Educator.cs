using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Educator
    {
        public string ID { get; set; }
        public string SubjectsID { get; set; }
        public string FullName { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }

        public Subject Subjects { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
