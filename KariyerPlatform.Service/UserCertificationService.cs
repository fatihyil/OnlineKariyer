using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserCertificationService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserCertificationService(OnlineKariyerDbContext context)
        {
            _context = context;
        }



        public void Add(UserCertification entity)
        {
            _context.UserCertification.Add(entity);
            _context.SaveChanges();
        }
              
        public List<UserCertification> GetUserDetail(string UserId)
        {
            var entity = _context.UserCertification.Where(x => x.UserId == UserId).ToList();
            return entity;
        }
    }
}
