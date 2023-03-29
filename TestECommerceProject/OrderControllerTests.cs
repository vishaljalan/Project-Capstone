using Microsoft.AspNetCore.Mvc;

using MongoMicroservice.Models;
using MongoMicroservice.Data_Access;
using Moq;
using System.Threading.Tasks;
using Xunit;
using MongoMicroservice.Controllers;

namespace MongoMicroservice.UnitTests.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<Iorder> _orderMock;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _orderMock = new Mock<Iorder>();
            _controller = new OrderController(_orderMock.Object);
        }

        [Fact]
        public async Task GetOrderById_ShouldReturnOkResult()
        {
            // Arrange
            string orderId = "123456";
            var expectedOrderDetails = new OrderDetails() { id = orderId };

            _orderMock.Setup(x => x.getOrderId(orderId))
                .ReturnsAsync(expectedOrderDetails);

            // Act
            var result = await _controller.getOrderById(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orderDetails = Assert.IsAssignableFrom<OrderDetails>(okResult.Value);
            Assert.Equal(orderId, orderDetails.id);
        }

        [Fact]
        public async Task AddOrder_ShouldReturnOkResult()
        {
            // Arrange
            var order = new OrderDetails() { id = "123456", name = "Product1" };
            var expectedOrderId = "789012";
            var expectedOrderDetails = new OrderDetails() { id = expectedOrderId, name = "Product1" };

            _orderMock.Setup(x => x.addOrder(order))
                .ReturnsAsync(expectedOrderId);

            _orderMock.Setup(x => x.getOrderId(expectedOrderId))
                .ReturnsAsync(expectedOrderDetails);

            // Act
            var result = await _controller.addOrder(order);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orderDetails = Assert.IsAssignableFrom<OrderDetails>(okResult.Value);
            Assert.Equal(expectedOrderId, orderDetails.id);
        }
    }
}
