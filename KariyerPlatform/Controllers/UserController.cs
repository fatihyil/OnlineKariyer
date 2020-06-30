using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerPlatform.Data.Entities;
using KariyerPlatform.Models;
using KariyerPlatform.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace KariyerPlatform.Controllers
{
    public class UserController : Controller
    {
        private readonly UserInfoService _service;
        private readonly UserExperienceService _userExperienceService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserLanguageService _userLanguageService;
        private readonly UserEducationService _userEducationService;
        private readonly UserCertificationService _userCertificationService;
        private readonly JobAdvertService _jobAdvertService;
        public UserController(UserInfoService service, UserManager<IdentityUser> userManager, UserExperienceService userExperienceService, UserLanguageService userLanguageService, UserEducationService userEducationService, UserCertificationService userCertificationService,JobAdvertService jobAdvertService)
        {
            _service = service;
            _userManager = userManager;
            _userExperienceService = userExperienceService;
            _userLanguageService = userLanguageService;
            _userEducationService = userEducationService;
            _userCertificationService = userCertificationService;
            _jobAdvertService = jobAdvertService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Info(string Id)
        {
            var UserName = await _userManager.FindByNameAsync(Id);
            var ıd = UserName.Id;
            var model = new UserInfoVM();
            model.UserId = ıd;
            model.UserName = UserName.UserName;
            return View(model);
        }
        [HttpPost]
        public IActionResult Info(UserInfoVM user)
        {
            var entity = new UserInfo()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Birthdate = user.Birthdate,
                City = user.City,
                Description = user.Description,
                Phone = user.Phone,
                Email = user.Email
            };
            _service.Update(entity);
            return Ok();
        }

        [HttpPost]
        public IActionResult Experience(UserExperienceVM model)
        {
            var entity = new UserExperience()
            {
                UserId = model.UserId,
                CompanyName = model.CompanyName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                JobDescription = model.JobDescription,
                JobPosition = model.JobPosition,
                WorkType = model.WorkType
            };
            _userExperienceService.Add(entity);
            return Ok();
        }
        [HttpPost]
        public IActionResult Language(UserLanguageVM model)
        {

            var entity = new UserLanguage()
            {
                UserId = model.UserId,
                Language = model.Language,
                LanguageLevel = model.LanguageLevel
            };
            _userLanguageService.Add(entity);
            return Ok();
        }
        [HttpPost]
        public IActionResult Education(UserEducationVM model)
        {
            var entity = new UserEducation()
            {
                University = model.University,
                Faculty = model.Faculty,
                Study = model.Study,
                StudyType = model.StudyType,
                StartDate = model.StartDate,
                EducationType = model.EducationType,
                EndDate = model.EndDate,
                UserId = model.UserId
            };
            _userEducationService.Add(entity);

            return Ok();
        }
        [HttpPost]
        public IActionResult Certification(UserCertificationVM model)
        {
            var entity = new UserCertification()
            {
                CertificationName = model.CertificationName,
                Company = model.Company,
                Date = model.Date,
                UserId = model.UserId
            };
            _userCertificationService.Add(entity);
            return Ok();
        }
        public async Task<IActionResult> ApplyJob(int id )
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var asdf = _jobAdvertService.GetJobAdvertUserWithQuery(x => x.JobAdvertId == id && x.UserId == user.Id);

            if (asdf != null)
            {
                TempData["SuccessMessage"] = "Daha Önce başvurdun bea!";
                return RedirectToAction("Detail", "JobAdvert", new { id = id });
            }

            var entity = new JobAdvertUser()
            {
                JobAdvertId = id,
                UserId = user.Id
            };
            _jobAdvertService.Add(entity);
            TempData["SuccessMessage"] = "Başarılı bir Şekilde Başvurdunuz.";
            return RedirectToAction("Detail", "JobAdvert", new { id = id });
        }


        public string getUser(string UserName)
        {
            var userId = _service.GetUser(UserName);
            return userId.ToString();
        }

        public IActionResult DeleteJob(int id)
        {
            _jobAdvertService.DeleteJobAdvert(id);
            return RedirectToAction("Detail", "JobAdvert", new { id = id });
        }



        public async Task<IActionResult> Detail(string Id)
        {
            var UserName = await _userManager.FindByNameAsync(Id);
            var ıd = UserName.Id;
            var userınfo = _service.GetUserDetail(ıd);
            var userlanguage = _userLanguageService.GetUserDetail(ıd);
            var usercertification = _userCertificationService.GetUserDetail(ıd);
            var usereducation = _userEducationService.GetUserDetail(ıd);
            var userexperience = _userExperienceService.GetUserDetail(ıd);


            var model = new UserDetailVM();

            model.UserId = userınfo.UserId;
            model.UserName = userınfo.UserName;
            model.LastName = userınfo.LastName;
            model.Phone = userınfo.Phone;
            model.FirstName = userınfo.FirstName;
            model.Email = userınfo.Email;
            model.Description = userınfo.Description;
            model.City = userınfo.City;
            model.Birthdate = userınfo.Birthdate;
            model.Address = userınfo.Address;

            foreach (var item in userlanguage)
            {
                model.userLanguages.Add(new UserLanguageVM()
                {
                    Language = item.Language,
                    LanguageLevel = item.LanguageLevel,
                    Id = item.Id
                });
            }
            foreach (var item in usercertification)
            {
                model.userCertifications.Add(new UserCertificationVM()
                {
                    Id = item.Id,
                    Company = item.Company,
                    CertificationName = item.CertificationName,
                    Date = item.Date
                });
            }
            foreach (var item in usereducation)
            {
                model.UserEducations.Add(new UserEducationVM()
                {
                    Id = item.Id,
                    StartDate = item.StartDate,
                    Study = item.Study,
                    StudyType = item.StudyType,
                    EducationType = item.EducationType,
                    EndDate = item.EndDate,
                    Faculty = item.Faculty,
                    University = item.University                    
                });
            }
            foreach (var item in userexperience)
            {
                model.userExperiences.Add(new UserExperienceVM()
                {
                    Id = item.Id,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    CompanyName = item.CompanyName,
                    JobDescription = item.JobDescription,
                    JobPosition= item.JobPosition,
                    WorkType = item.WorkType
                });
            }

            return View(model);
        }













        //public IActionResult Detail(string Id)
        //{
        //    var userInformation = _service.GetUserDetail(Id);
        //    var userCertification = _userCertificationService.GetUserDetail(Id);
        //    var userLanguage = _userLanguageService.GetUserDetail(Id);
        //    var userEducation = _userEducationService.GetUserDetail(Id);
        //    var userExperience = _userExperienceService.GetUserDetail(Id);
        //    var model = new UserDetailVM()
        //    {
        //        UserName = userInformation.UserName,
        //        FirstName = userInformation.FirstName,
        //        LastName = userInformation.LastName,
        //        Address = userInformation.Address,
        //        Birthdate = userInformation.Birthdate,
        //        City = userInformation.City,
        //        Email = userInformation.Email,
        //        Phone = userInformation.Phone,
        //        Description = userInformation.Description,    
        //    };
        //    return View();
        //}
    }
}
