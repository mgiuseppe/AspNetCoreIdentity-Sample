using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentitySample.Models;
using Microsoft.AspNetCore.Identity;
using AspNetCoreIdentitySample.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace AspNetCoreIdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<MyUserEntity> _userManager;

        public HomeController(UserManager<MyUserEntity> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
