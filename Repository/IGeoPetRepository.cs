using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface IGeoPetRepository
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(int userId);
        UserDTO AddUser(User user);
        UserDTO UpdateUser(User user, int userId);
        void DeleteUser(int userId);
    }
}