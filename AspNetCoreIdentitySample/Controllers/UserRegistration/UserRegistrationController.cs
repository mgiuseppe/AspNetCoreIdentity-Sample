using AspNetCoreIdentitySample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentitySample.Controllers.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRegistrationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check if user exists
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                    ModelState.AddModelError("User Already Exists", "User Already Exists");
                else
                {
                    //create user (NormalizedUsername and Password are populated by UserManager)
                    user = new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.UserName
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if(!result.Succeeded)
                        foreach (var e in result.Errors)
                            ModelState.AddModelError(e.Code, e.Description);
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(HomeController.Success), "Home");
            else
                return View();
        }
    }
}