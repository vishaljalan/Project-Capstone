using MediatR;
using ProductMicroservice.Models;

namespace UserMicroservice.Command
{
    public record updateUserCommand(Users user, int id) : IRequest<string>;
}
