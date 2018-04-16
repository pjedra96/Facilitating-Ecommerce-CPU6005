using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WesthoughtonWorldOfWicker.Data;
using WesthoughtonWorldOfWicker.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WesthoughtonWorldOfWicker.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;
        private readonly string _shoppingCartId;
        public const string CartSessionKey = "CartId";

        private ShoppingCart(ApplicationDbContext context, string id)
        {
            _context = context;
            _shoppingCartId = id;
        }

        public static ShoppingCart GetCart(ApplicationDbContext db, HttpContext context)
            => GetCart(db, GetCartId(context));

        public static ShoppingCart GetCart(ApplicationDbContext db, string cartId)
            => new ShoppingCart(db, cartId);

        public async Task AddToCart(Product product)
        {
            // Get the matching cart and album instances
            var cartItem = await _context.Cart.SingleOrDefaultAsync(
                c => c.CartId == _shoppingCartId
                && c.ProductId == product.ProductId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    ProductId = product.ProductId,
                    CartId = _shoppingCartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                _context.Cart.Add(cartItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Quantity++;
            }
        }


        public int IncreaseQuantity(int id)
        {
            // Get the cart
            var cartItem = _context.Cart.SingleOrDefault(
                cart => cart.CartId == _shoppingCartId
                && cart.CartItemId == id);

            int itemCount = 0;

            if (cartItem != null)
            {

                if (cartItem.Quantity > 0)
                {
                    cartItem.Quantity++;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    _context.Cart.Add(cartItem);
                    _context.SaveChangesAsync();
                }
            }
            
            return itemCount;
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _context.Cart.SingleOrDefault(
                cart => cart.CartId == _shoppingCartId
                && cart.CartItemId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    _context.Cart.Remove(cartItem);
                    _context.SaveChangesAsync();
                }
            }

            return itemCount;
        }

        public async Task EmptyCart()
        {
            var cartItems = await _context.Cart
                .Where(cart => cart.CartId == _shoppingCartId)
                .ToArrayAsync();
            _context.Cart.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public Task<List<Cart>> GetCartItems()
        {
            return _context.Cart
                .Where(cart => cart.CartId == _shoppingCartId)
                .Include(c => c.Product)
                .ToListAsync();
        }

        public Task<List<string>> GetCartProductNames()
        {
            return _context.Cart
                .Where(cart => cart.CartId == _shoppingCartId)
                .Select(c => c.Product.ModelName)
                .OrderBy(n => n)
                .ToListAsync();
        }

        public Task<int> GetCount()
        {
            // Get the count of each item in the cart and sum them up
            return _context.Cart
                .Where(c => c.CartId == _shoppingCartId)
                .Select(c => c.Quantity)
                .SumAsync();
        }

        public Task<decimal> GetTotal()
        {
            // Multiply product price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total

            return _context.Cart
                .Include(c => c.Product)
                .Where(c => c.CartId == _shoppingCartId)
                .Select(c => c.Product.UnitCost * c.Quantity)
                .SumAsync();
        }

        public async Task<int> CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = await GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var product = await _context.Product.SingleAsync(a => a.ProductId == item.ProductId);

                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitCost = product.UnitCost,
                    Quantity = item.Quantity,
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Quantity * product.UnitCost);
                _context.OrderDetail.Add(orderDetail);
                await _context.SaveChangesAsync();
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Empty the shopping cart
            await EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // We're using HttpContextBase to allow access to sessions.
        private static string GetCartId(HttpContext context)
        {
            var cartId = context.Session.GetString("Session");

            if (cartId == null)
            {
                //A GUID to hold the cartId. 
                cartId = Guid.NewGuid().ToString();

                // Send cart Id as a cookie to the client.
                context.Session.SetString("Session", cartId);
            }

            return cartId;
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string email)
        {
            var shoppingCart = _context.Cart.Where(
                c => c.CartId == _shoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = email;
            }
            _context.SaveChangesAsync();
        }
    }
}