using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductMicroservice.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserMicroservice.Command;
using UserMicroservice.Controllers;
using UserMicroservice.Data_Access;
using UserMicroservice.Queries;
using UsersMicroservice.Data_Access;
using Xunit;

namespace UserMicroservice.Tests
{
    public class UsersControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly UsersController _userController;
       


        public UsersControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _userController = new UsersController(_mediatorMock.Object);
        }



        [Fact]
        public async void GetAllUsers_ShouldReturnListOfUsers()
        {
            //Arrange
            var users = new List<Users>
            {
 new Users { Id = 1, FirstName = "John ",LastName = "Doe", Email = "johndoe@example.com",  },
 new Users { Id = 2, FirstName = "Jane ",LastName = "Doe", Email = "janedoe@example.com"  }
 };



            _mediatorMock.Setup(x => x.Send(It.IsAny<getAllUsersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);



            //Act
            var result = await _userController.getAllUsers();



            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task addNewUser_Returns200StatusCode()
        {
            // Arrange
            var user = new Users { Id = 1, FirstName = "John" , LastName="forq"};

            // Act
            var result = await _userController.addNewUser(user);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status200OK, (result as StatusCodeResult)?.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<addUserCommand>(), default), Times.Once);
        }

        [Fact]
        public async Task deleteUser_Returns200StatusCode()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _userController.deleteUser(id);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status200OK, (result as StatusCodeResult)?.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<deleteUserCommand>(), default), Times.Once);
        }

        //[Fact]
        //public async Task updateUser_Returns200StatusCode()
        //{
        //    // Arrange
        //    var user = new Users { Id = 1, FirstName = "John", LastName = "forq" };
            
        //    // Act
        //    var result = await _userController.updateUser(id,user);

        //    // Assert
        //    Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(StatusCodes.Status200OK, (result as StatusCodeResult)?.StatusCode);
        //    _mediatorMock.Verify(x => x.Send(It.IsAny<updateUserCommand>(), default), Times.Once);
        //}
    }




}


