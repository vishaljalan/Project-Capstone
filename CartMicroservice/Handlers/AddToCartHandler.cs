using CartMicroservice.Commands;
using CartMicroservice.Data_Access;
using CartMicroservice.Queries;
using MediatR;

namespace CartMicroservice.Handlers
{
    // Handlers/Cart/AddToCartHandler.cs
    public class AddToCartHandler : IRequestHandler<AddToCartCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public AddToCartHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.AddToCartAsync(request.ProductId, request.UserId);
        }
    }








}
