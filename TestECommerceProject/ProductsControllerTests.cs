using Moq;
using Xunit;
using ProductMicroservice.Controllers;
using ProductMicroservice.Models;
using ProductMicroservice.Queries;
using ProductMicroservice.Commands;
using MediatR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class ProductsControllerTests
{
    [Fact]
    public async Task GetAllProducts_ReturnsListOfProducts()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var expectedProductsList = new List<Products>()
        {
            new Products() { ProductId = 1, Name = "Product 1", CategoryId = 1 },
            new Products() { ProductId = 2, Name = "Product 2", CategoryId = 1 },
            new Products() {ProductId = 3, Name = "Product 3", CategoryId = 2 }
        };
        mediatorMock.Setup(m => m.Send(It.IsAny<getAllProductsQuery>(), default))
                    .ReturnsAsync(expectedProductsList);
        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.getAllProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualProductsList = Assert.IsAssignableFrom<List<Products>>(okResult.Value);
        Assert.Equal(expectedProductsList, actualProductsList);
    }

    [Fact]
    public async Task GetProductById_ReturnsProduct()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var expectedProduct = new Products() { ProductId = 1, Name = "Product 1", CategoryId = 1 };
        mediatorMock.Setup(m => m.Send(It.IsAny<getProductByIdQuery>(), default))
                    .ReturnsAsync(expectedProduct);
        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.getProductById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualProduct = Assert.IsType<Products>(okResult.Value);
        Assert.Equal(expectedProduct, actualProduct);
    }

    [Fact]
    public async Task GetProductByCategoryId_ReturnsListOfProducts()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var expectedProductsList = new List<Products>()
        {
            new Products() { ProductId = 1, Name = "Product 1", CategoryId = 1 },
            new Products() { ProductId = 2, Name = "Product 2", CategoryId = 1 },
        };
        mediatorMock.Setup(m => m.Send(It.IsAny<getAllProductsByCategoryIdQuery>(), default))
                    .ReturnsAsync(expectedProductsList);
        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.getProductByCategoryId(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualProductsList = Assert.IsAssignableFrom<List<Products>>(okResult.Value);
        Assert.Equal(expectedProductsList, actualProductsList);
    }

    //[Fact]
    //public async Task AddNewProduct_ReturnsStatusCode200()
    //{
    //    // Arrange
    //    var mediatorMock = new Mock<IMediator>();
    //    var productToAdd = new Products() { Name = "Product 1", CategoryId = 1 };
    //    var controller = new ProductsController(mediatorMock.Object);

    //    // Act
    //    var result = await controller.addNewProduct(productToAdd);

    //    // Assert
    //    Assert.IsType<StatusCodeResult>(result);
    //    var statusCodeResult = (StatusCodeResult)result;
    //    Assert.Equal(200, statusCodeResult.StatusCode);
    //}

    [Fact]
    public async Task DeleteProduct_ReturnsStatusCode200()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var productIdToDelete = 1;
        var controller = new ProductsController(mediatorMock.Object);

        // Act
        var result = await controller.deleteProduct(productIdToDelete);

        // Assert
        Assert.IsType<StatusCodeResult>(result);
        var statusCodeResult = (StatusCodeResult)result;
        Assert.Equal(200, statusCodeResult.StatusCode);
        mediatorMock.Verify(m => m.Send(It.Is<deleteProductCommand>(c => c.id == productIdToDelete), default), Times.Once);
    }

    //[Fact]
    //public async Task UpdateProduct_ReturnsStatusCode200()
    //{
    //    // Arrange
    //    var mediatorMock = new Mock<IMediator>();
    //    var productToUpdate = new Products() { ProductId = 1, Name = "Product 1 Updated", CategoryId = 2 };
    //    var controller = new ProductsController(mediatorMock.Object);

    //    // Act
    //    var result = await controller.updateProduct(productToUpdate);

    //    // Assert
    //    Assert.IsType<StatusCodeResult>(result);
    //    var statusCodeResult = (StatusCodeResult)result;
    //    Assert.Equal(200, statusCodeResult.StatusCode);
    //    mediatorMock.Verify(m => m.Send(It.Is<updateProductCommand>(c => c.product == productToUpdate), default), Times.Once);
    //}

}