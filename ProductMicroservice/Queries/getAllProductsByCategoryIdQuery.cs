using MediatR;
using ProductMicroservice.Models;

namespace ProductMicroservice.Queries
{
    public record getAllProductsByCategoryIdQuery(int id):IRequest<List<Products>>;
    
}
