using CartMicroservice.Commands;
using CartMicroservice.Controllers;
using CartMicroservice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductMicroservice.Data_Access;
using ProductMicroservice.Models;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CartMicroservice.Tests
{

    public class CartControllerTests
    {
        [Fact]
        public async Task GetCart_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;
            var mockMediator = new Moq.Mock<IMediator>();
            var mockCart = new Carts { UserId = userId };
            mockMediator.Setup(m => m.Send(It.IsAny<GetCartQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockCart);
            var cartController = new CartController(mockMediator.Object, null);



            // Act
            var result = await cartController.GetCart(userId);



            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        //[Fact]
        //public async Task AddToCart_ShouldReturnStatusCode200_WhenCalledWithValidData()
        //{
        //    // Arrange
        //    var mediatorMock = new Mock<IMediator>();
        //    var contextMock = new Mock<CapstoneDbContext>();
        //    var controller = new CartController(mediatorMock.Object, contextMock.Object);
        //    var cart = new CartMicroservice.Models.dto.cartFromFrontEnd { productId = 1, userId = 1 };



        //    mediatorMock
        //    .Setup(m => m.Send(It.IsAny<AddToCartCommand>(), It.IsAny<CancellationToken>()))
        //    .ReturnsAsync(1);



        //    // Act
        //    var result = await controller.AddToCart(cart);



        //    // Assert
        //    Assert.IsType<StatusCodeResult>(result);
        //    var statusCodeResult = result as StatusCodeResult;
        //    Assert.Equal(200, statusCodeResult.StatusCode);
        //}
    }
}
 