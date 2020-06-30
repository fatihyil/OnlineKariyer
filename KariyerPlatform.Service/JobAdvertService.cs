using KariyerPlatform.Data.Context;
using KariyerPlatform.Data.Entities;
using KariyerPlatform.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KariyerPlatform.Service
{
    public class JobAdvertService
    {
        private readonly OnlineKariyerDbContext _context;
        public JobAdvertService(OnlineKariyerDbContext context)
        {
            _context = context;
        }

        public List<JobAdvertCompanyDTO> GetJobAdverts()
        {
            var result = _context.Company.Join(_context.JobAdvert,
                company => company.Id,
                jobadvert => jobadvert.CompanyId, (company, jobadvert) => new JobAdvertCompanyDTO
                {
                    CompanyId = company.Id,
                    CompanyName = company.CompanyName,
                    JobPosition = jobadvert.JobPosition,
                    JobAdvertId = jobadvert.Id
                }).ToList();
            return result;
        }

        public JobAdvertDetailDTO GetJobDetail(int id)
        {
            var applyjobcount = _context.JobAdvertUser.Where(x => x.JobAdvertId == id).Count();
            var result = _context.Company.Join(_context.JobAdvert,
                    company => company.Id,
                    jobadvert => jobadvert.CompanyId,
                    (company, jobadvert) => new JobAdvertDetailDTO
                    {
                        JobAdvertId = jobadvert.Id,
                        JobDescription = jobadvert.JobDescription,
                        JobPosition = jobadvert.JobPosition,
                        CompanyName = company.CompanyName,
                        WorkerCount = company.WorkerCount,
                        ApplyCount=applyjobcount
                    }                
                ).FirstOrDefault(x=>x.JobAdvertId== id);
            return result;
        }

        public string GetUser(string UserName)
        {
            var entity = _context.UserInfo.FirstOrDefault(x => x.UserName == UserName);
            var entityId = entity.UserId;
            return entityId;
        }


        public void Add(JobAdvertUser entity)
        {
            _context.JobAdvertUser.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<JobAdvertUser> GetJobAdvertUserWithQueryList(Expression<Func<JobAdvertUser, bool>> exp)
        {
            return _context.Set<JobAdvertUser>().Where(exp);
        }

        public JobAdvertUser GetJobAdvertUserWithQuery(Expression<Func<JobAdvertUser, bool>> exp)
        {
            return _context.Set<JobAdvertUser>().FirstOrDefault(exp);
        }

        public void DeleteJobAdvert(int id)
        {
            var entity = _context.JobAdvertUser.FirstOrDefault(x => x.JobAdvertId == id);
            _context.JobAdvertUser.Remove(entity);
            _context.SaveChanges();
        }
    }
}
