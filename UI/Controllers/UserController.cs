using Core.DTOs;
using Core.Enums;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _userService.GetUser(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        /*[HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserUpdateDTO model)
        {
            _userService.UpdateUser(id, model);
            return RedirectToAction("Index");
        }*/
        
        [HttpGet]
        public IActionResult UpgradeUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult UpgradeUser(int id, UpgradeLibraryUserRequestModel model)
        {
            _userService.UpgrageLibraryUser(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, UpdateUserStatusRequestModel model)
        {
            _userService.UpdateUserStatus(id, model);
            return RedirectToAction("Index");
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateUserRequestModel model)
        {
            _userService.RegisterUser(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userService.RegisterLibrarian(user);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Login(email, password);
            if (user == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            else if(user.Status != AccountStatus.ACTIVE)
            {
                ViewBag.Message = "Account Not Active";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                var userRole = user.UserType.ToString();
                if (userRole == "LibraryUser")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (userRole == "Librarian")
                {
                    return RedirectToAction("AdminDashboard", "User");
                }

                return RedirectToAction("Login", "User");
            }

        }
    }
}
