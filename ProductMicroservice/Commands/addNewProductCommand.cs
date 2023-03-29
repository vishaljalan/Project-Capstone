using MediatR;
using ProductMicroservice.Models;
using ProductMicroservice.Models.dto;

namespace ProductMicroservice.Commands
{
    public record addNewProductCommand(Productdto product):IRequest<string>;
    
}
