using Microsoft.AspNetCore.Mvc;
using task_6.Models;

namespace task_6.Controllers
{
    public class ProdectController : Controller
    {
        private readonly MyDbContext _context;

        public ProdectController(MyDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Prodects.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Prodect prodect)
        {
            _context.Prodects.Add(prodect);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            var prodect =_context.Prodects.Find(Id);
            return View(prodect);
        }

        public IActionResult Edit(int Id)
        {
            var prodect = _context.Prodects.Find(Id);
            return View(prodect);
        }

        [HttpPost]
        public IActionResult Edit(Prodect prodect)
        {
            _context.Prodects.Update(prodect);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

       


        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var x = Request.Form["Id"];
            var prodect = _context.Prodects.Find(Id);
            _context.Prodects.Remove(prodect);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
