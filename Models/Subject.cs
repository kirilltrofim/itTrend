using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Subject
    {
        public string ID { get; set; }
        public string Subjects { get; set; }
        public ICollection<Educator> Educators { get; set; }
    }
}
