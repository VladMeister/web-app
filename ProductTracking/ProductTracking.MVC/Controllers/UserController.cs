using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.MVC.Models;

namespace ProductTracking.MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _mapper
                    .Map<IEnumerable<UserDto>, IEnumerable<UserModel>>(_userService.GetAllUsers());

            return View(users);
        }

        [HttpPost]
        public IActionResult UserSearch(string searchString)
        {
            var user = _mapper
                    .Map<UserDto, UserModel>(_userService.GetUserByLogin(searchString));

            if (user != null)
            {
                return PartialView(user);
            }

            return PartialView();
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var user = _userService.GetUserById(id);

                if (user != null)
                {
                    _userService.DeleteUser(user);
                    TempData["message"] = $"User {user.Login} was deleted.";

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", $"No such user was found.");
            return View();
        }
    }
}