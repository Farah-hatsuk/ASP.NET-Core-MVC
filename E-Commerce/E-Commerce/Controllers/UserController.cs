using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }


        // create new user 
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");

        }




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       
        public IActionResult Login(User user)
        {
            
                var userinfo = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (userinfo != null)
                {

                    HttpContext.Session.SetString("UserName", userinfo.Name);
                    HttpContext.Session.SetString("UserRole", userinfo.Role);
                    HttpContext.Session.SetString("UserEmail", userinfo.Email);

                    if (userinfo.Role == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    return RedirectToAction("Index", "User");


                }             
            


            return View();
        }




        // show detailte of the prodect 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult Profile()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }


        public IActionResult EditProfile()
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }


        [HttpPost]
        public IActionResult EditProfile(User updateuser)
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            user.Name = updateuser.Name;
            user.Email = updateuser.Email;
            _context.SaveChanges();
            HttpContext.Session.SetString("UserEmail", updateuser.Email);
            ViewBag.msg2 = "Update seccessfully";

            return RedirectToAction("Profile");
        }







    }
}
