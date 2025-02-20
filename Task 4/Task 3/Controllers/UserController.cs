using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Task_3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleRegister(string name, string email, string password, string repeatPassword)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", password);
            HttpContext.Session.SetString("RepeatPassword", repeatPassword);


            if (password != repeatPassword)
            {
                TempData["ErrorMsg"] = "Password dosent match";
                //ViewBag.ErrorMsg = "Password dosent match";
                return RedirectToAction("Register");
            }

            return RedirectToAction("Login");

        }






        public IActionResult Login()
        {

                return View();
            
        }

        [HttpPost]
        public IActionResult HandleLogin(string email, string password , string check)
        {
            var Email = HttpContext.Session.GetString("Email");
            var Password = HttpContext.Session.GetString("Password");

            if (email == Email && password == Password)
            {

                if (check != null)
                {
                    CookieOptions obj = new CookieOptions();
                    obj.Expires = DateTime.Now.AddDays(2);
                    //store
                    Response.Cookies.Append("userInfo", email, obj);
                }

                return RedirectToAction("Index", "Home");
            }

            



            TempData["ErrorMsg1"] = "Password or Email not valid";
            return RedirectToAction("Login");


        
        }





        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");

        }







        public IActionResult Profile()
        {

            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.Address = HttpContext.Session.GetString("Address");
            ViewBag.Phone = HttpContext.Session.GetString("Phone");

            return View();
        }

        public IActionResult EditProfile(string name, string email, string password, string address, string phone)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", password);
            HttpContext.Session.SetString("Address", address);
            HttpContext.Session.SetString("Phone", phone);


            return RedirectToAction("Profile");

        }




    }
}
