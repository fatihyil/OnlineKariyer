using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserEducationService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserEducationService(OnlineKariyerDbContext context)
        {
            _context = context;
        }

        public void Add(UserEducation entity)
        {
            _context.UserEducation.Add(entity);
            _context.SaveChanges();
        }
        public List<UserEducation> GetUserDetail(string UserId)
        {
            var entity = _context.UserEducation.Where(x => x.UserId == UserId).ToList();
            return entity;
        }


    }
}
