using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerPlatform.Service.DTO
{
    public class JobAdvertDetailDTO
    {
        public int JobAdvertId { get; set; }
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public string CompanyName { get; set; }
        public int WorkerCount { get; set; }
        public int ApplyCount { get; set; }

    }
}
