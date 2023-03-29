using CartMicroservice.Commands;
using CartMicroservice.Data_Access;
using CartMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;
using System.Runtime.Intrinsics.X86;
using System;
using ProductMicroservice.Data_Access;

namespace CartMicroservice.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CapstoneDbContext _context;

        public CartRepository(CapstoneDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddToCartAsync(int productId, int userId)
        {
            //var cart = await _context.Carts.SingleOrDefaultAsync(c => c.UserId == userId);
            //if (cart == null)
            //{
            //    cart = new Carts { UserId = userId };
            //    _context.Carts.Add(cart);
            //    await _context.SaveChangesAsync();
            //}

            //var cartItem = await _context.CartItems.SingleOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == productId);
            //if (cartItem == null)
            //{
            //    cartItem = new CartItems { CartId = cart.CartId, ProductId = productId, Quantity = 1, };
            //    _context.CartItems.Add(cartItem);
            //}
            //else
            //{
            //    cartItem.Quantity++;
            //}
            //await _context.SaveChangesAsync();

            //return cart.CartId;

            // Find the cart for the user
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                // If no cart exists, create a new one
                cart = new Carts { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }



            // Check if the product is already in the cart
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                // If the product is not in the cart, add it
                cartItem = new CartItems { ProductId = productId, CartId = cart.CartId, Quantity = 1 };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                // If the product is already in the cart, increase the quantity
                cartItem.Quantity++;
            }



            // Recalculate the total price of the cart
            cart.TotalPrice += (await _context.Products.FindAsync(productId)).Price;



            // Save the changes to the database
            await _context.SaveChangesAsync();



            return cart.CartId;
        }

        public async Task<Carts> GetCartAsync(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Products).SingleOrDefaultAsync(c => c.UserId == userId);
            return cart;
        }

        public async Task<bool> UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var cartItem = await _context.CartItems.SingleOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.Include(ci => ci.Carts).SingleOrDefaultAsync(ci => ci.CartItemId == cartItemId);
            if (cartItem != null)
            {
                // Update the total price
                var productPrice = (await _context.Products.FindAsync(cartItem.ProductId)).Price;
                cartItem.Carts.TotalPrice -= productPrice * cartItem.Quantity;



                // Remove the cart item
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CheckoutAsync(int userId)
        {
            // Implement the checkout process here (e.g., create an order, clear the cart, etc.)
            return true;
        }


        public async Task<bool> ClearCartAsync(int userId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                cart.TotalPrice = 0;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
   
}
