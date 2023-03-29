using CartMicroservice.Commands;
using CartMicroservice.Data_Access;
using MediatR;

namespace CartMicroservice.Handlers
{
    // Handlers/Cart/RemoveCartItemHandler.cs
    public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveCartItemHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.RemoveCartItemAsync(request.CartItemId);
        }
    }
}
