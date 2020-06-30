﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerPlatform.Data.Entities
{
    public class UserInfo
    {
        [Key]
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
        



    }
}
