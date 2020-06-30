using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserLanguageService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserLanguageService(OnlineKariyerDbContext context)
        {
            _context = context;
        }
        public void Add(UserLanguage entity)
        {
            _context.UserLanguage.Add(entity);
            _context.SaveChanges();

        }
        public List<UserLanguage> GetUserDetail(string UserId)
        {
            var entity = _context.UserLanguage.Where(x => x.UserId == UserId).ToList();
            return entity;
        }


    }
}
