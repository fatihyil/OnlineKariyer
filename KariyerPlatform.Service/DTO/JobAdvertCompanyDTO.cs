using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerPlatform.Service.DTO
{
    public class JobAdvertCompanyDTO
    {
        public int CompanyId { get; set; }
        public int JobAdvertId { get; set; }

        public string JobPosition { get; set; }
        public string CompanyName { get; set; }

    }
}
