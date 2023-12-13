using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleASPCore.Models;
using SampleASPCore.ViewModels;

namespace SampleASPCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            //konek db cek user etc
            if (!(loginViewModel.Username == "erick" && loginViewModel.Password == "rahasia"))
                return Unauthorized();

            //buat session
            HttpContext.Session.SetString("username", loginViewModel.Username);
            MyRole myRole = new MyRole { RoleName = "Admin", IsRead = true, IsWrite = true };
            string strRole = JsonSerializer.Serialize(myRole);

            HttpContext.Session.SetString("role", strRole);

            return LocalRedirect("/Home/Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("role");
            return LocalRedirect("/Account/Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}