using MediatR;
using UserMicroservice.Command;
using ProductMicroservice.Models;
using UsersMicroservice.Data_Access;

namespace UserMicroservice.Handler
{
    public class addUserHandler : IRequestHandler<addUserCommand, List<Users>>
    {
        private readonly Iuser _user;

        public addUserHandler(Iuser user)
        {
            _user = user;
        }
        public Task<List<Users>> Handle(addUserCommand request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_user.addNewUser(request.user));
        }
    }
}
