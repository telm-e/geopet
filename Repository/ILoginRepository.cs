using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface ILoginRepository
    {
        public Login GetUserByEmail(string email);
    }
}