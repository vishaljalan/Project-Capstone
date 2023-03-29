using MediatR;

namespace CartMicroservice.Commands
{
    // Commands/Queries/Cart/CheckoutCommand.cs
    public record CheckoutCommand(int UserId) : IRequest<bool>;

}
