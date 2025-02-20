using Microsoft.AspNetCore.Mvc;

namespace Task_3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
