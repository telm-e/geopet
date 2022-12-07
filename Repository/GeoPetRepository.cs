using geo_pet.Models;
using Microsoft.EntityFrameworkCore;

namespace geo_pet.Repository
{
    public class GeoPetRepository : IGeoPetRepository
    {   
        protected readonly GeoPetContext _context;
        public GeoPetRepository(GeoPetContext context)
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
                    Password = x.Password,
                });
            return users;
        }
        
    }
}
