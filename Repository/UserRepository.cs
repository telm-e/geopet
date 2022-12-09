using geo_pet.Models;
using Microsoft.EntityFrameworkCore;

namespace geo_pet.Repository
{
    public class UserRepository : IUserRepository
    {   
        protected readonly GeoPetContext _context;
        public UserRepository(GeoPetContext context)
        {
            _context = context;
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _context.Users
                .Select(x => new UserDTO{
                    UserId = x.UserId,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Cep = x.Cep,
                });
            return users;
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _context.Users.Where(user => user.UserId == userId)
                .Select(x => new UserDTO{
                    UserId = x.UserId,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Cep = x.Cep,
                    }).First();
            return user;
        }

        public UserDTO AddUser(User user)
        {
            var userAdd = new User {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
                Password = user.Password
            };
            _context.Users.Add(userAdd);
            _context.SaveChanges();
            return new UserDTO {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
            };
        }

        public UserDTO UpdateUser(User user, int userId)
        {
            var myUser = _context.Users.Find(userId);
            Console.WriteLine(myUser);
            if (myUser != null)
            {
                myUser.Name = user.Name;
                myUser.Email = user.Email;
                myUser.Phone = user.Phone;
                myUser.Cep = user.Cep;
                _context.SaveChanges();
            }
            return new UserDTO {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
            };
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            Console.WriteLine(user);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        
    }
}