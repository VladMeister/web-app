using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.MVC.Models;

namespace ProductTracking.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Login()
        {
            return Index();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.ExistingUser(model.Login, model.Password))
                {
                    string roleName = _userService.GetUserRole(model.Login);
                    var user = new UserModel() { Login = model.Login, Password = model.Password, RoleName = roleName };

                    Authenticate(user);
                    TempData["message"] = $"Welcome, {model.Login}";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password!");
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return Index();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_userService.ExistingUser(model.Login, model.Password))
                {
                    string roleName = _userService.GetUserRole(model.Login);

                    var user = new UserModel() { Login = model.Login, Password = model.Password, RoleName = roleName };
                    var userDTO = _mapper.Map<UserModel, UserDto>(user);

                    Authenticate(user);

                    _userService.RegisterUser(userDTO);
                    TempData["message"] = $"Welcome, {model.Login}";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "User with such login already exists!");
                }
            }
            return View(model);
        }

        private void Authenticate(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}