using MediatR;
using ProductMicroservice.Models;

namespace UserMicroservice.Queries
{
    public record getAllUsersQuery:IRequest<List<Users>>;
    
}
