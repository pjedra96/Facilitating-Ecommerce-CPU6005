using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;

namespace WesthoughtonWorldOfWicker.Components
{
    [ViewComponent(Name = "CartSummary")]
    public class CartSummaryComponent : ViewComponent
    {
        private ApplicationDbContext _context;

       public CartSummaryComponent(ApplicationDbContext context)
       {
            _context = context;
       }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            var cartItems = await cart.GetCartItems();
            var numberItems = await cart.GetCount();

            ViewBag.CartCount = numberItems;
            ViewBag.CartSummary = string.Join("\n", cartItems);

            return View();
        }
    }
}