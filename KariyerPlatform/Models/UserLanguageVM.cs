using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class UserLanguageVM
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string LanguageLevel { get; set; }
        public string UserId { get; set; }

    }
}
