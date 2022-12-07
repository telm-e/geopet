using Microsoft.EntityFrameworkCore.Infrastructure;

namespace geo_pet.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public string Password { get; set; }
        public List<Pet>? Pets { get; set; }
    }

    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public string Password { get; set; }
    }
}