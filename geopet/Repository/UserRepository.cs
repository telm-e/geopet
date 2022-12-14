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
                .Select(x => new UserDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Cep = x.Cep,
                    Pets = x.Pets.Select(p => new PetDTOUser
                    {
                        PetId = p.PetId,
                        Name = p.Name,
                        Age = (DateTime.Now.Year - p.Birth.Year),
                        Size = p.Size,
                        Breed = p.Breed,
                        Hash = p.Hash,
                    }).ToList()
                });

            return users;
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _context.Users.Where(user => user.UserId == userId)
                .Select(x => new UserDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Cep = x.Cep,
                    Pets = x.Pets.Select(p => new PetDTOUser
                    {
                        PetId = p.PetId,
                        Name = p.Name,
                        Age = (DateTime.Now.Year - p.Birth.Year),
                        Size = p.Size,
                        Breed = p.Breed,
                        Hash = p.Hash,
                    }).ToList()
                }).First();
            return user;
        }

        public UserDTOUpdate AddUser(UserDTOAdd user)
        {
            var userAdd = new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
                Password = user.Password
            };
            _context.Users.Add(userAdd);
            _context.SaveChanges();
            return new UserDTOUpdate
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
            };
        }

        public UserDTOUpdate UpdateUser(User user, int userId)
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
            return new UserDTOUpdate
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Cep = user.Cep,
            };
        }
        public void DeleteUser(int userId)
        {
            var pets = _context.Pets.FirstOrDefault(x => x.UserId == userId);
            if (pets != null)
            {
                throw new ArgumentException("Delete os pets vinculados ao usuário");
            }
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            Console.WriteLine(user);
            if (user == null)
            {
                throw new ArgumentException("User Not Found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}