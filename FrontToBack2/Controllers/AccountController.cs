using Microsoft.AspNetCore.Mvc;

namespace FrontToBack2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Registr()
        {
            return View();
        }



        public IActionResult Login()
        {
            return View();
        }

    }
}
