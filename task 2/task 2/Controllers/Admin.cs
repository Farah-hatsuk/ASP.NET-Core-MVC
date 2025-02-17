using Microsoft.AspNetCore.Mvc;

namespace task_2.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
