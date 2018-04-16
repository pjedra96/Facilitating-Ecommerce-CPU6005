using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WesthoughtonWorldOfWicker.Models;
using WesthoughtonWorldOfWicker.Data;

namespace WesthoughtonWorldOfWicker.Components
{
    [ViewComponent(Name = "CategoryMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        private ApplicationDbContext _context;

        public GenreMenuComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Category.Select(g => g.CategoryName).Take(5).ToListAsync();

            return View(categories);
        }
    }
}