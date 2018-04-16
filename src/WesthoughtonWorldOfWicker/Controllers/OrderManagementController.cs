using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;

namespace WesthoughtonWorldOfWicker.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderManagementController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: OrderManagement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDetail.Include(o => o.Order).Include(o => o.Product).ThenInclude(o => o.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.SingleOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderManagement/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ModelName");
            return View();
        }

        // POST: OrderManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductId,Quantity,UnitCost")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "Address", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ModelName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.SingleOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ModelName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Quantity,UnitCost")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ModelName", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.SingleOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetail.SingleOrDefaultAsync(m => m.Id == id);
            _context.OrderDetail.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.Id == id);
        }
    }
}
