using geo_pet.Models;
using Microsoft.EntityFrameworkCore;

namespace geo_pet.Repository
{
    public class LoginRepository : ILoginRepository
    {   
        protected readonly GeoPetContext _context;
        public LoginRepository(GeoPetContext context)
        {
            _context = context;
        }

        public Login GetUserByEmail(string email)
        {
            var user = _context.Users.Where(user => user.Email == email)
                .Select(x => new Login{
                    Email = x.Email,
                    Password = x.Password,
                    }).First();
            return user;
        }
        
    }
}