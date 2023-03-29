using CartMicroservice.Commands;
using CartMicroservice.Data_Access;
using MediatR;

namespace CartMicroservice.Handlers
{
    public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;



        public ClearCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }



        public async Task<bool> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.ClearCartAsync(request.UserId);
        }
    }
}