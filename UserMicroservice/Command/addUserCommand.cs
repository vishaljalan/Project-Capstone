using MediatR;
using ProductMicroservice.Models;

namespace UserMicroservice.Command
{
    public record addUserCommand(Users user):IRequest<List<Users>>;
   
}
