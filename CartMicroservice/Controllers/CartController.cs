using CartMicroservice.Commands;
using CartMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;
using System.Buffers.Text;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using ProductMicroservice.Data_Access;
using CartMicroservice.Models.dto;

namespace CartMicroservice.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        private readonly CapstoneDbContext _context;

        public CartController(IMediator mediator, CapstoneDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        [Route("addToCart")]
        public async Task<IActionResult> AddToCart([FromBody]cartFromFrontEnd cart)
        {
            var productId = cart.productId;
            var userId = cart.userId;
            //var usernameClaim = User.FindFirst("Username");

            //if (usernameClaim == null)
            //{
            //    return Unauthorized();
            //}

            //var currentUser = _context.Users.SingleOrDefault(u => u.Username == usernameClaim.Value);

            //if (currentUser == null)
            //{
            //    return Unauthorized();
            //}

            await _mediator.Send(new AddToCartCommand(productId, userId));
            //return RedirectToAction("GetCart");
            return StatusCode(200);
        }

        [HttpGet]

        [Route("/getCart/{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {

            //var usernameClaim = User.FindFirst("Username");

            //if (usernameClaim == null)
            //{
            //    return Unauthorized();
            //}

            //var currentUser = _context.Users.SingleOrDefault(u => u.Username == usernameClaim.Value);

            //if (currentUser == null)
            //{
            //    return Unauthorized();
            //}
            var cart = await _mediator.Send(new GetCartQuery(userId));
            return Ok(cart);
        }

        [HttpPut]
        [Route("updateCartItem")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, int quantity)
        {
            await _mediator.Send(new UpdateCartItemCommand(cartItemId, quantity));
            return RedirectToAction("GetCart");
        }

        [HttpDelete]
        [Route("/deleteCartItem/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            await _mediator.Send(new RemoveCartItemCommand(cartItemId));
            return RedirectToAction("GetCart");
        }




        [HttpDelete]
        [Route("clearCart/{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            var result = await _mediator.Send(new ClearCartCommand(userId));
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }



        [HttpPut]
        [Route("checkout")]
        public async Task<IActionResult> Checkout()
        {

            var usernameClaim = User.FindFirst("Username");

            if (usernameClaim == null)
            {
                return Unauthorized();
            }

            var currentUser = _context.Users.SingleOrDefault(u => u.Username == usernameClaim.Value);

            if (currentUser == null)
            {
                return Unauthorized();
            }
            await _mediator.Send(new CheckoutCommand(currentUser.Id));
            return View();
        }
    }



    //retrieve the UserId from the claims stored in the JWT token.
    //Assuming you have the UserId stored as a claim named "UserId" in the token,
    //you can use the following method in your CartController to get the UserId:

    //private int GetUserId()
    //{
    //    if (User.Identity.IsAuthenticated)
    //    {
    //        var userIdClaim = User.FindFirst("UserId");
    //        if (userIdClaim != null)
    //        {
    //            if (int.TryParse(userIdClaim.Value, out int userId))
    //            {
    //                return userId;
    //            }
    //        }
    //    }
    //    // If the UserId claim is not found, or the user is not authenticated, return an invalid UserId (e.g., 0)
    //    return 0;


    //    //This method first checks if the user is authenticated.
    //    //If they are, it searches for a claim named "UserId" in the User.Claims collection.If it finds the claim,
    //    //it tries to parse the value as an integer and returns it.If the claim is not found or the user is not authenticated,
    //    //it returns an invalid UserId(e.g., 0).

    //    //Make sure to adjust the claim name "UserId" based on the name you are using when creating the JWT token.
    //





}
    
