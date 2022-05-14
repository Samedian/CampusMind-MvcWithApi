using CampusMindBussinessAccessLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CampusMind.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBAL _accountBAL;
        public AccountController(IAccountBAL accountBAL)
        {
            _accountBAL = accountBAL;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            string roleassign = _accountBAL.Access(username, password);

            if (roleassign != null)
            {
                HttpContext.Session.SetString("UserName", username);

                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,roleassign)
            }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticate = true;
            }



            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                TempData["User"] = HttpContext.Session.GetString("UserName");


                if (roleassign.Equals("User") || roleassign.Equals("user"))
                    RedirectToAction("Index", "CampusMind");

            }

            return View();


        }
    
}
}
