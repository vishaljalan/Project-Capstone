using MediatR;

namespace UserMicroservice.Command
{
    public record deleteUserCommand(int id):IRequest<string>;
  
}
