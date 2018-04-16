using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesthoughtonWorldOfWicker.Models;
using WesthoughtonWorldOfWicker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WesthoughtonWorldOfWicker.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["OrderId"] = new SelectList(_context.OrderDetail, "OrderId", "OrderId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OrderId"] = new SelectList(_context.OrderDetail, "OrderId", "OrderId", review.OrderId);
            return View(review);
        }
    }
}