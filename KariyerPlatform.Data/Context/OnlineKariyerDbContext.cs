using KariyerPlatform.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerPlatform.Data.Context
{
    public class OnlineKariyerDbContext : DbContext
    {
        public OnlineKariyerDbContext(DbContextOptions<OnlineKariyerDbContext> options)
            : base(options)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<JobAdvertUser>(eb =>
        //    {
        //       eb.HasNoKey();                     
        //    });




        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserExperience> UserExperience { get; set; }
        public DbSet<UserEducation> UserEducation { get; set; }
        public DbSet<UserCertification> UserCertification { get; set; }
        public DbSet<UserLanguage> UserLanguage { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<JobAdvert> JobAdvert { get; set; }
        public DbSet<JobAdvertUser> JobAdvertUser { get; set; }
    }
}
