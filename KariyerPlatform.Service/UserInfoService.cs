using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerPlatform.Service
{
    public class UserInfoService
    {
        private readonly OnlineKariyerDbContext _context;
        public UserInfoService(OnlineKariyerDbContext context)
        {
            _context = context;
        }
        public void Add(UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
        }
        public string GetUser(string UserName)
        {
            var entity = _context.UserInfo.FirstOrDefault(x => x.UserName == UserName);
            var entityId = entity.UserId;
            return entityId;
        }
        public void Update(UserInfo user)
        {
            if (user != null)
            {
                //var entity = _context.UserInfo.FirstOrDefault(x => x.UserId == user.UserId);
                _context.UserInfo.Update(user);
                _context.SaveChanges();
            }
        }

        public UserInfo GetUserDetail(string UserId)
        {
            var entity = _context.UserInfo.FirstOrDefault(x => x.UserId == UserId);
            return entity;
        }
    }
}
