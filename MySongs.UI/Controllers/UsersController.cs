using Microsoft.AspNetCore.Mvc;
using MySongs.Services.Interfaces;
using MySongs.Common.DTOs;

namespace MySongs.UI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserDto user)
        {
            _userService.Add(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserDto user)
        {
            _userService.Update(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}