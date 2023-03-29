using MediatR;

namespace CartMicroservice.Commands
{
    // Commands/Queries/Cart/RemoveCartItemCommand.cs
    public record RemoveCartItemCommand(int CartItemId) : IRequest<bool>;

}
