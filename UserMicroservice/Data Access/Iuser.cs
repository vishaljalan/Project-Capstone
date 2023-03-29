using ProductMicroservice.Models;

namespace UsersMicroservice.Data_Access
{
    public interface Iuser
    {


        public List<Users> getAllUsers();

        public List<Users> addNewUser(Users user);

        public string deleteUser(int id);

        public string updateUser(Users user, int id);



    }
}
