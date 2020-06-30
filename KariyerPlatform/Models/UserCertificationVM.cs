using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class UserCertificationVM
    {
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }

        public string UserId { get; set; }
    }
}
