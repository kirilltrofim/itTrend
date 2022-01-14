using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public Educator Educators { get; set; }

    }
}
