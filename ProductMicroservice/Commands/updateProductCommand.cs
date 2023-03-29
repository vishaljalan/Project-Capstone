using MediatR;
using ProductMicroservice.Models;
using ProductMicroservice.Models.dto;

namespace ProductMicroservice.Commands
{
    public record updateProductCommand(Productdto product):IRequest<string>;
  
}
