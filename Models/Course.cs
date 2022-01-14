using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int Number { get; set; }

        public ICollection<Group> Group { get; set; }
    }
}
