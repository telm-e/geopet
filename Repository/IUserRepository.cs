using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface IUserReporitory
    {
        IEnumerable<UserDTO> GetUsers();
    }
}