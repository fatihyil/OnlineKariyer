using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace KariyerPlatform.Data.Entities
{
    public class JobAdvert
    {
        public int Id { get; set; }
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public int CompanyId { get; set; }
        
    }
}
