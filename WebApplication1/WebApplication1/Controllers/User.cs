using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class User : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Rigester()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
