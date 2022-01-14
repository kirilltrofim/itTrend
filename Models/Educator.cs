using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using itTrend.Models;

namespace itTrend.Models
{
    public class Educator
    {
        [Key]
        public int GroupID { get; set; }

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronomic { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string SubjectID { get; set; }

        public Group GroupOf { get; set; }

        ICollection<Subject> Subject { get; set; }

    }
}
