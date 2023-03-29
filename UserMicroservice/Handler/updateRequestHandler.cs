using MediatR;
using UserMicroservice.Command;
using UsersMicroservice.Data_Access;

namespace UserMicroservice.Handler
{
    public class updateRequestHandler : IRequestHandler<updateUserCommand, string>
    {
        private readonly Iuser _user;

        public updateRequestHandler(Iuser user)
        {
            
            _user = user;
        }

        public Task<string> Handle(updateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_user.updateUser(request.user, request.id));
        }
    }
}
