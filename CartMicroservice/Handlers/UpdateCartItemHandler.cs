using CartMicroservice.Commands;
using CartMicroservice.Data_Access;
using MediatR;

namespace CartMicroservice.Handlers
{
    // Handlers/Cart/UpdateCartItemHandler.cs
    public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartItemHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.UpdateCartItemAsync(request.CartItemId, request.Quantity);
        }
    }
}
