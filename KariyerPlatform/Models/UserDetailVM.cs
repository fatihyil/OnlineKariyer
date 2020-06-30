using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerPlatform.Models
{
    public class UserDetailVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthdate { get; set; }
        public string Description { get; set; }
        //public UserInfoVM  UserInfo { get; set; }
        public List<UserCertificationVM> userCertifications { get; set; }
        public List<UserEducationVM> UserEducations { get; set; }
        public List<UserExperienceVM> userExperiences { get; set; }
        public List<UserLanguageVM> userLanguages { get; set; }
        
    }
}
