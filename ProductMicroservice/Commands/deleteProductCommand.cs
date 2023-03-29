using MediatR;

namespace ProductMicroservice.Commands
{
    public record deleteProductCommand(int id):IRequest<string>;
   
}
