using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.Queries
{
    public record getAllProductsQuery:IRequest<List<Products>>;
    
}
