using MediatR;
using ProductMicroservice.Models;
using UserMicroservice.Queries;
using UserMicroservice.Repository;
using UsersMicroservice.Data_Access;

namespace UserMicroservice.Handler
{
    public class getAllUsersHandler : IRequestHandler<getAllUsersQuery, List<Users>>
    {
        private readonly Iuser _user;

        public getAllUsersHandler(Iuser user)
        {
            _user = user;
        }
        public async Task<List<Users>> Handle(getAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_user.getAllUsers());
        }
    }
}
