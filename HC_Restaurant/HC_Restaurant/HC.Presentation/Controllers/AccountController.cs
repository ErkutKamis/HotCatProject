using HC.Application.Extensions;
using Hc.Application.Models.DTO;
using Hc.Application.Service.Interface;
using HC.Application.Validation.FluentValidation;
using HC.Domain.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HC.Presentation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAppUserService appUserService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _userManager = userManager;
        }

        #region Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            RegisterDTOValidation validator = new RegisterDTOValidation();
            var results = validator.Validate(model);
            if (results.IsValid)
            {
                var result = await _appUserService.Register(model);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email); //kullaniciyi email üzerinde kontrol et.
                    MailSender.SendMail(user.Email, "Hotcat Activation", $"<h2>Welcome {user.UserName}!!</h2> <hr /> Please click the link below to activate your subscription <br /> https://localhost:7149/Account/Activation/" + user.Id);
                    return RedirectToAction("Pending", user);
                }
                foreach (var item in result.Errors)
                {
                    TempData["message"] = item.Description + "\n";
                }
                return View();
            }
            foreach (var item in results.Errors)
            {
                TempData["message"] += item.ErrorMessage + "\n";
            }
            return View(model);
        }
        #endregion

        #region Pending
        [AllowAnonymous]
        public IActionResult Pending(AppUser user)
        {
            if (user != null)
                return View(user);

            else
                return RedirectToAction("Register");
        }
        #endregion

        #region Activation
        [AllowAnonymous]
        public async Task<IActionResult> Activation(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirm = await _userManager.ConfirmEmailAsync(user, token);

                if (confirm.Succeeded)
                {
                    TempData["message"] = "Congratulations, your subscription has been completed. You can login here.";
                    return RedirectToAction("SignIn");
                }
                TempData["message"] = "An error has occurred. Please check your information.";
                return RedirectToAction("Register");
            }
            return RedirectToAction("Register");
        }
        #endregion

        #region SignIn
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> SignIn(LoginDTO model)
        {
            LoginDTOValidation validator = new LoginDTOValidation();
            var results = validator.Validate(model);
            if (results.IsValid)
            {
                if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("ErrLogin", "Please enter a username and password.");
                    return View(model);
                }

                var result = await _appUserService.Login(model);

                if (result.Succeeded)
                {
                    if (model.UserName == "Admin")
                    {
                        // Admin kullanıcısı ise AdminIndex() metoduna yönlendir
                        return RedirectToAction("AdminIndex", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        // Admin kullanıcısı değilse normal sayfaya yönlendir ve hata mesajı göster
                        TempData["message"] = "You do not have access to this page.";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("ErrLogin", "Incorrect entry");
                }
            }
            foreach (var item in results.Errors)
            {
                TempData["message"] += item.ErrorMessage + "\n";
            }
            return View(model);
        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();

            return RedirectToAction("SignIn");
        }
        #endregion

        #region ProfilePage
        public async Task<IActionResult> Profile(string userName)
        {
            if (User.Identity.Name == userName)
            {
                var user = await _appUserService.GetByUser(userName);

                if (user != null)
                {
                    return View(user);
                }

            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region EditProfile
        public async Task<IActionResult> EditProfile(string userName)
        {
            if (User.Identity.Name == userName)
            {
                var user = await _appUserService.GetByUser(userName);

                if (user != null)
                {
                    var updatedUser = await _appUserService.GetById(user.ID);
                    return View(updatedUser);
                }
                return NotFound();
            }

            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateUserDTO model)
        {
            UpdateUserDTOValidation validator = new UpdateUserDTOValidation();
            var resultValidator = validator.Validate(model);
            if (resultValidator.IsValid)
            {
                TempData["message"] = await _appUserService.UpdateUser(model);
                var user = await _userManager.FindByIdAsync(model.ID);
                return RedirectToAction("Profile", "Account", new { userName = user.UserName }, null);
            }
            else
            {
                foreach (var item in resultValidator.Errors)
                {
                    TempData["message"] += item.ErrorMessage + "\n";
                }
                return View(model);
            }
        }
        #endregion
    }
}
