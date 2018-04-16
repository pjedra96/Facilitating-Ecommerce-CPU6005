using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;
using WesthoughtonWorldOfWicker.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WesthoughtonWorldOfWicker.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context, ILogger<ShoppingCartController> logger)
        {
            _context = context;
            _logger = logger;
        }
        //
        // GET: /ShoppingCart/
        public async Task<IActionResult> Index()
        {
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = await cart.GetCartItems(),
                CartTotal = await cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /ShoppingCart/AddToCart/5

        public async Task<IActionResult> AddToCart(int id, CancellationToken requestAborted)
        {
            // Retrieve the product from the database
            var addedProduct = await _context.Product
                .SingleAsync(product => product.ProductId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            await cart.AddToCart(addedProduct);

            await _context.SaveChangesAsync(requestAborted);
            _logger.LogInformation("Product {productId} was added to the cart.", addedProduct.ProductId);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncreaseQuantity(int id, CancellationToken requestAborted)
        {

            // Retrieve the current user's shopping cart
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            // Get the name of the album to display confirmation
            var cartItem = await _context.Cart
                .Where(item => item.CartItemId == id)
                .Include(c => c.Product)
                .SingleOrDefaultAsync();

            string message;
            int itemCount;

            if (cartItem != null)
            {
                // Add to cart
                itemCount = cart.IncreaseQuantity(id);

                await _context.SaveChangesAsync(requestAborted);

                string added = (itemCount > 0) ? " 1 copy of " : string.Empty;
                message = added + cartItem.Product.ModelName + " has been added to your shopping cart.";
            }
            else
            {
                itemCount = 0;
                message = "Could not find this item, nothing has been added to your shopping cart.";
            }
            // Increase the quantity

            var viewModel = new ShoppingCartAddViewModel
            {
                Message = message,
                CartTotal = await cart.GetTotal(),
                CartCount = await cart.GetCount(),
                ItemCount = itemCount,
                AddId = id
            };

            _logger.LogInformation("Product {id} was added to a cart.", id);

            // Return the view
            return Json(viewModel);
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(
            int id,
            CancellationToken requestAborted)
        {
            // Retrieve the current user's shopping cart
            var cart = ShoppingCart.GetCart(_context, HttpContext);

            // Get the name of the product to display confirmation
            var cartItem = await _context.Cart
                .Where(item => item.CartItemId == id)
                .Include(c => c.Product)
                .SingleOrDefaultAsync();

            string message;
            int itemCount;
            if (cartItem != null)
            {
                // Remove from cart
                itemCount = cart.RemoveFromCart(id);

                await _context.SaveChangesAsync(requestAborted);

                string removed = (itemCount > 0) ? " 1 copy of " : string.Empty;
                message = removed + cartItem.Product.ModelName + " has been removed from your shopping cart.";
            }
            else
            {
                itemCount = 0;
                message = "Could not find this item, nothing has been removed from your shopping cart.";
            }

            // Display the confirmation message

            var results = new ShoppingCartRemoveViewModel
            {
                Message = message,
                CartTotal = await cart.GetTotal(),
                CartCount = await cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            _logger.LogInformation("Product {id} was removed from a cart.", id);

            return Json(results);
        }
    }
}