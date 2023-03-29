using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Command;
using UserMicroservice.Data_Access;
using ProductMicroservice.Models;
using UserMicroservice.Queries;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("/getAllUsers")]
        
        public async Task<IActionResult> getAllUsers()
        {
            var UsersList = await _mediator.Send(new getAllUsersQuery());
            return Ok(UsersList);

        }

        [HttpPost]
        [Route("/addNewUser")]
        public async Task<IActionResult> addNewUser([FromBody] Users user)
        {
             await _mediator.Send(new addUserCommand(user));
            return StatusCode(200);
        }


        [HttpDelete]
        [Route("/deleteUser/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            await _mediator.Send(new deleteUserCommand(id));
            return StatusCode(200);
        }


        [HttpPut]
        [Route("/updateUser/{id}")]
        public async Task<IActionResult> updateUser([FromBody]Users user,int id)
        {
            await _mediator.Send(new updateUserCommand(user, id));
            return StatusCode(200);

        }


        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody]Users user)
        {
            


            var res = await _mediator.Send(new loginCommand(user));
            if (res == null)
            {
                return BadRequest("user not found");
            }
            return Ok(res);

        }

    }
}
