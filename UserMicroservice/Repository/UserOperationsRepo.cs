using ProductMicroservice.Data_Access;

using ProductMicroservice.Models;
using UsersMicroservice.Data_Access;

namespace UserMicroservice.Repository
{
    public class UserOperationsRepo : Iuser
    {
        private readonly CapstoneDbContext _context;

        public UserOperationsRepo(CapstoneDbContext context)
        {
            _context = context;
        }


        public List<Users> addNewUser(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                

            }catch (Exception ex)
            {
                throw new InvalidDataException("Unable to add this users due to :"+ ex.Message);

            }
            return _context.Users.ToList();
        }

        public string deleteUser(int id)
        {
            
            try
            {
                var user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    
                }
            }
            catch(Exception ex)
            {
                
                throw new InvalidDataException("Unable to delete this users due to :" + ex.Message);
                
            }
            return "Deleted Boss";


        }

        public List<Users> getAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Unable to retrive the data");
            }
        }

        public string updateUser(Users user, int id)
        {   
            var currentUser = _context.Users.Find(id);
            try
            {
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.Password = user.Password;
                currentUser.Role = user.Role;

                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Unable to update the data");
            }
            return "Updated Boss";
        }
    }

}
