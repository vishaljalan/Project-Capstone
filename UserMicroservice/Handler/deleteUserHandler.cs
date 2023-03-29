using MediatR;
using UserMicroservice.Command;
using UsersMicroservice.Data_Access;

namespace UserMicroservice.Handler
{
    public class deleteUserHandler : IRequestHandler<deleteUserCommand, string>
    {
        private readonly Iuser _user;

        public deleteUserHandler(Iuser user)
        {
            _user = user;
        }
        public Task<string> Handle(deleteUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.deleteUser(request.id));
        }
    }
}
