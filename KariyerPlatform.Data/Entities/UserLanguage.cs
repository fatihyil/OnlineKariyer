using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KariyerPlatform.Data.Entities
{
    public class UserLanguage
    {
        [Key]
        public int Id { get; set; }
        public string Language { get; set; }
        public string LanguageLevel { get; set; }

    
        public string UserId { get; set; }
       


    }
}
