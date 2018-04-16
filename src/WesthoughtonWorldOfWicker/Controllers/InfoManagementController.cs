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
    public class InfoManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfoManagementController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: InfoManagement
        public async Task<IActionResult> Index()
        {
            return View(await _context.Info.ToListAsync());
        }

        // GET: InfoManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.SingleOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: InfoManagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,City,Country,County,Email,FirstName,LastName,Phone,Postcode")] Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(info);
        }

        // GET: InfoManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.SingleOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: InfoManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,City,Country,County,Email,FirstName,LastName,Phone,Postcode")] Info info)
        {
            if (id != info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
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
            return View(info);
        }

        // GET: InfoManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Info.SingleOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: InfoManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Info.SingleOrDefaultAsync(m => m.Id == id);
            _context.Info.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InfoExists(int id)
        {
            return _context.Info.Any(e => e.Id == id);
        }
    }
}
