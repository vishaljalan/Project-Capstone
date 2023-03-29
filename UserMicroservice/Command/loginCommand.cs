using MediatR;
using ProductMicroservice.Models;
using UserMicroservice.Models.dto;

namespace UserMicroservice.Command
{
    public record loginCommand(Users user):IRequest<loginresultdto>;
    
}
