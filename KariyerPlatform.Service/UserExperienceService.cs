using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserExperienceService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserExperienceService(OnlineKariyerDbContext context)
        {
            _context = context;
        }
        public void Add(UserExperience user)
        {
            _context.UserExperience.Add(user);
            _context.SaveChanges();

        }
        public int ExpCount()
        {
            var count = _context.UserExperience.Count();
            return count;
        }

        public List<UserExperience> GetUserDetail(string UserId)
        {
            var entity = _context.UserExperience.Where(x => x.UserId == UserId).ToList();
            return entity;
        }





    }
}
