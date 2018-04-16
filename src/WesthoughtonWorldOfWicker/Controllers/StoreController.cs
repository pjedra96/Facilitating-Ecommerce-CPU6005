using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;

namespace WesthoughtonWorldOfWicker.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        //
        // GET: /Store/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        //
        // GET: /Store/ViewOrders
        [Authorize]
        public async Task<IActionResult> ViewOrders()
        {
            var user = HttpContext.User.Identity.Name;
            var orders = await _context.OrderDetail.Include(o => o.Order).Include(o => o.Product).ThenInclude(o => o.Category).Where(item => item.Order.Username == user).ToListAsync();
            return View(orders);
        }

        //
        // GET: /Store/Browse?category=
        public async Task<IActionResult> Browse(string category)
        {
            var product = await _context.Category.Include(p => p.Products).Where(m => m.CategoryName == category).FirstOrDefaultAsync();
            return View(product);
        }
        //
        // GET: /Store/Details
        public IActionResult Details(int id)
        {

            var product = _context.Product.Find(id);
            return View(product);
        }

        //
        // GET: /Store/CategoryMenu
        public ActionResult CategoryMenu()
        {
            var categories = _context.Category.ToListAsync();
            return PartialView(categories);
        }
    }
}