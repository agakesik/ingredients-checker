using ICDataManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ICDataManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, IConfiguration config)
        {
            _logger = logger;
            _signInManager = signInManager;
            _config = config;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Admin");
            }

            ViewData["UIBaseUrl"] = _config.GetValue<string>("UIBaseUrl");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
