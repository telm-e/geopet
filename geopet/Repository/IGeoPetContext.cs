using Microsoft.EntityFrameworkCore;
using geo_pet.Models;

namespace geo_pet.Repository 
{
    public interface IGeoPetContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public int SaveChanges();
    }
}