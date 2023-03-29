
using MediatR;
using ProductMicroservice.Models;

namespace CartMicroservice.Queries
{
    // Commands/Queries/Cart/GetCartQuery.cs
    public record GetCartQuery(int UserId) : IRequest<Carts>;
}
