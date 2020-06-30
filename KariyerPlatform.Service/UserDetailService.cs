using KariyerPlatform.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserDetailService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserDetailService(OnlineKariyerDbContext context)
        {
            _context = context;
        }




    }
}
