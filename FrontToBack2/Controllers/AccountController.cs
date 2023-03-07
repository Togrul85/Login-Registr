using FrontToBack2.Models;
using FrontToBack2.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Registr(RegistrVM registr)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new();
            
            user.Email = registr.Email;
            user.Fullname= registr.Fullname;
            user.UserName =registr.Username;
        IdentityResult result =   await _userManager.CreateAsync(user, registr.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(registr);

            }
            //sign in

            await _signInManager.SignInAsync(user, true);



            
return RedirectToAction("Index","home");

        }


        public IActionResult Login()
        {
            return View();
        }

    }
}
