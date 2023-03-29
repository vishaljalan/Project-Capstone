using ProductMicroservice.Models;
using UserMicroservice.Models.dto;

namespace UserMicroservice.Data_Access
{
    public interface Iuserlogin
    {
        public loginresultdto Login(Users user);
        public Users authenticate(Users user);

        public string generateToken(Users user);

        public void registerUsers(Users user);
    }
}

