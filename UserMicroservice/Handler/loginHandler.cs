using MediatR;
using Microsoft.AspNetCore.Identity;
using UserMicroservice.Command;
using UserMicroservice.Data_Access;
using UserMicroservice.Models.dto;

namespace UserMicroservice.Handler
{
    public class loginHandler : IRequestHandler<loginCommand, loginresultdto>
    {
        private readonly Iuserlogin login;

        public loginHandler(Iuserlogin login)
        {
            this.login = login;
        }
        public Task<loginresultdto> Handle(loginCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(login.Login(request.user));
        }
    }
}
