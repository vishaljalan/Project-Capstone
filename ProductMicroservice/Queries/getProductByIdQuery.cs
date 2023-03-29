using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.Queries
{
    public record getProductByIdQuery(int id): IRequest<Products>;
 
}
