using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KariyerPlatform.Data.Entities
{
    public class UserCertification
    {
        public int Id { get; set; }
        public string CertificationName { get; set; }
        public string Company { get; set; }
        public string Date { get; set; }

        public string UserId { get; set; }
       
    }
}
