using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface IGeoPetRepository
    {
        IEnumerable<UserDTO> GetUsers();
    }
}