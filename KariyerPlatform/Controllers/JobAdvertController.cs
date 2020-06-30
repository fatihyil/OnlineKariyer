using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerPlatform.Models;
using KariyerPlatform.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KariyerPlatform.Controllers
{
    public class JobAdvertController : Controller
    {
        private readonly JobAdvertService _service;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JobAdvertService _jobAdvertService;

        public JobAdvertController(JobAdvertService service,UserManager<IdentityUser> userManager,JobAdvertService jobAdvertService)
        {
            _service = service;
            _userManager = userManager;
            _jobAdvertService = jobAdvertService;
        }
        public IActionResult Index()
        {
            var entity = _service.GetJobAdverts();
            var model = new List<JobAdvertVM>();

            foreach (var item in entity)
            {
                model.Add(new JobAdvertVM
                {
                    CompanyName = item.CompanyName,
                    JobPosition = item.JobPosition,
                    Id = item.JobAdvertId
                });
            }
            
            return View(model);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var entity = _service.GetJobDetail(id);
            var asdf = _jobAdvertService.GetJobAdvertUserWithQuery(x => x.JobAdvertId == id && x.UserId == appUser.Id);

            if (asdf != null)
            {
                TempData["ApplyJob"] = true;
            }
            else
            {
                TempData["ApplyJob"] = false;
            }
            var model = new JobAdvertDetailVM()
            {
                JobAdvertId = entity.JobAdvertId,
                JobPosition = entity.JobPosition,
                JobDescription = entity.JobDescription,
                CompanyName = entity.CompanyName,
                WorkerCount = entity.WorkerCount,
                ApplyCount = entity.ApplyCount,
                UserId = appUser.Id                
            };

            return View(model);

        }
      

    }
}
