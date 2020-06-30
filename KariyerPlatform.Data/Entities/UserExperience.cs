using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KariyerPlatform.Data.Entities
{
    public class UserExperience
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobPosition { get; set; }
        public string JobDescription { get; set; }
        public string WorkType { get; set; }
        public string UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual UserInfo UserInfo { get; set; }
    }
}
