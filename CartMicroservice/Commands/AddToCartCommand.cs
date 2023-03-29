using MediatR;

namespace CartMicroservice.Commands
{
    // Commands/Queries/Cart/AddToCartCommand.cs
    public record AddToCartCommand(int ProductId, int UserId) : IRequest<int>;




}
