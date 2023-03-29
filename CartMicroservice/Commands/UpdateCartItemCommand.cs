using MediatR;

namespace CartMicroservice.Commands
{
    // Commands/Queries/Cart/UpdateCartItemCommand.cs
    public record UpdateCartItemCommand(int CartItemId, int Quantity) : IRequest<bool>;
}
