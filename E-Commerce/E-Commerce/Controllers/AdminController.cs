using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  _context.Products
                .FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create( Product product)
        {

            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Image")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

           
             _context.Update(product);
             await _context.SaveChangesAsync();

             return RedirectToAction(nameof(Index));


        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }







        // user 

        public async Task<IActionResult> IndexUsers()
        {
            return View(await _context.Users.ToListAsync());
        }



        public IActionResult UserDetails(int? id)
        {
            

            var user =  _context.Users.FirstOrDefault(m => m.Id == id);
            return View(user);
        }


        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]

        public IActionResult UserCreate(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(IndexUsers));

        }




        public async Task<IActionResult> UserEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]

        public async Task<IActionResult> UserEdit(int id, User user)
        {
            


            
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            
                
            
            return RedirectToAction(nameof(IndexUsers));

        }


        [HttpPost]
        public IActionResult UserDelete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("IndexUsers");
        }


    }
}
