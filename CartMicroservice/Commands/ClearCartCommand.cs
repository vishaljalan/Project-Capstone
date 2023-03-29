using MediatR;

namespace CartMicroservice.Commands
{
    public class ClearCartCommand : IRequest<bool>
    {
        public int UserId { get; }



        public ClearCartCommand(int userId)
        {
            UserId = userId;
        }
    }
}
