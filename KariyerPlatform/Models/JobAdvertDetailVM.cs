using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class JobAdvertDetailVM
    {
        public int JobAdvertId { get; set; }
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public string CompanyName { get; set; }
        public int WorkerCount { get; set; }
        public int ApplyCount { get; set; }
        public string UserId { get; set; }
    }
}
