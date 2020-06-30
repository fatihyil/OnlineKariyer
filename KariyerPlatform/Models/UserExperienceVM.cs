using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class UserExperienceVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public string WorkType { get; set; }
        public string UserId { get; set; }

    }
}
