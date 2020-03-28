using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var itemToDelete = _context.Items.FirstOrDefault(i => i.Id == id);
            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }
    }
}
