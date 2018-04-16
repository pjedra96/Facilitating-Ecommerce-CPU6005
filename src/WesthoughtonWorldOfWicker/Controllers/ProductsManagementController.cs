using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;
using Microsoft.AspNetCore.Authorization;

namespace WesthoughtonWorldOfWicker.Controllers
{
    [Authorize(Roles = "Administrator, Manager")]
    public class ProductsManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsManagementController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProductsManagement
        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Product.Include(p => p.Category);
            // LINQ search query
            var products = from m in applicationDbContext select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ModelName.Contains(searchString));
            }

            return View(await products.ToListAsync());
        }

        // GET: ProductsManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsManagement/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductsManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CategoryId,Description,ModelName,ModelNumber,UnitCost,productImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            // "CategoryId", "CategoryId"
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: ProductsManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: ProductsManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,CategoryId,Description,ModelName,ModelNumber,UnitCost,productImageUrl")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: ProductsManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
