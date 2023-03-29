using CartMicroservice.Data_Access;

using CartMicroservice.Queries;
using MediatR;
using ProductMicroservice.Models;

namespace CartMicroservice.Handlers
{
    // Handlers/Cart/GetCartHandler.cs
    public class GetCartHandler : IRequestHandler<GetCartQuery, Carts>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Carts> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartAsync(request.UserId);
        }
    }
}
