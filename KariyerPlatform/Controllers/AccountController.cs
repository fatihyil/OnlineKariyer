using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerPlatform.Data.Entities;
using KariyerPlatform.Models;
using KariyerPlatform.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KariyerPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserInfoService _userınfoservice;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,UserInfoService userInfoService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userınfoservice = userInfoService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var userInfo = new UserInfo()
            {
                UserId = user.Id,
                UserName = user.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _userınfoservice.Add(userInfo);
                return RedirectToAction(nameof(Login));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Kayıt Hatası", error.Description);
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Giriş Hatası", "Kullanıcı bilgilerinden kaynaklı bir hata oluştu");
                }
            }
            else
            {
                ModelState.AddModelError("Varolmayan kullanıcı.", "Girdiğiniz bilgiler ile eşleşen kullanıcı bulunamadı");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
