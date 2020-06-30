using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerPlatform.Data.Entities
{

    public class JobAdvertUser
    {
        [Key]
        public int Id { get; set; }
        public int JobAdvertId { get; set; }
        public string UserId { get; set; }
    }
}
