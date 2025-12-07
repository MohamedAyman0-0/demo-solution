using Microsoft.AspNetCore.Mvc;

namespace Session3Demo.Presentation.Controllers
{
    public class AccountController : Controller
    {
        //Register
        public IActionResult Register()
        {
            return View();
        }
        //Login
        public IActionResult Login()
        {
            return View();
        }
    }
}