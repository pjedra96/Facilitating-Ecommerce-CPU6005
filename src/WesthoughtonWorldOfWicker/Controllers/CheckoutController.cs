using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WesthoughtonWorldOfWicker.Models;
using WesthoughtonWorldOfWicker.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WesthoughtonWorldOfWicker.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ApplicationDbContext _context;

        public CheckoutController(ILogger<CheckoutController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //
        // GET: /Checkout/
        public IActionResult AddressAndPayment()
        {
            ViewData["InfoId"] = new SelectList(_context.Info, "Id", "Address");
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddressAndPayment(
            [FromServices] ApplicationDbContext _context,
            [FromForm] Order order,
            CancellationToken requestAborted)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            ViewData["InfoId"] = new SelectList(_context.Info, "Id", "Address", order.InfoId);
            var formCollection = await HttpContext.Request.ReadFormAsync();

            try
            {
                // If validation failed
                // Alternate code (for Promotion code use - insert into the ife statement) string.Equals(formCollection["PromoCode"].FirstOrDefault(), PromoCode,
                // StringComparison.OrdinalIgnoreCase) == false
                if (!IsCardNumberValid(formCollection["PromoCode"].FirstOrDefault()))
                {
                    // Return error view along with the error message
                    ViewBag.ErrorMessage = "The credit/debit card luhn algorithm check failed! Please ensure you have entered correct card number";
                    return View("Error");
                    //return View(order);
                }
                else
                {
                    order.Username = HttpContext.User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.CardNumber = formCollection["PromoCode"].FirstOrDefault();

                    //Add the Order
                    _context.Order.Add(order);

                    //Process the order
                    var cart = ShoppingCart.GetCart(_context, HttpContext);
                    await cart.CreateOrder(order);

                    _logger.LogInformation("User {userName} started checkout of {orderId}.", order.Username, order.OrderId);

                    // Save all changes
                    await _context.SaveChangesAsync(requestAborted);

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        // Credit/debit card validation (mod 10 Luhn algorithm) function
        public static bool IsCardNumberValid(string cardNumber)
        {

            int i, checkSum = 0;

            // Compute checksum of every other digit starting from right-most digit
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            // Now take digits not included in first checksum, multiple by two,
            // and compute checksum of resulting digits
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // Number is valid if sum of both checksums MOD 10 equals 0
            return ((checkSum % 10) == 0);
        }

        //
        // GET: /Checkout/Complete

        public async Task<IActionResult> Complete(
            [FromServices] ApplicationDbContext _context,
            int id)
        {
            var userName = HttpContext.User.Identity.Name;

            // Validate customer owns this order
            bool isValid = await _context.Order.AnyAsync(
                o => o.OrderId == id &&
                o.Username == userName);

            if (isValid)
            {
                _logger.LogInformation("User {userName} completed checkout on order {orderId}.", userName, id);

                var order = _context.Order.Find(id);
                var total = order.Total;
                ViewBag.Total = total;

                var vatfree = total * 100 / (100 + 20);
                ViewBag.VatFree = vatfree;
                return View(id);
            }
            else
            {
                _logger.LogError(
                    "User {userName} tried to checkout with an order ({orderId}) that doesn't belong to them.",
                    userName,
                    id);
                return View("Error");
            }
        }
    }
}