using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class UserEducationVM
    {
        public int Id { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Study { get; set; }
        public string StudyType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EducationType { get; set; }


        public string UserId { get; set; }
    }
}
