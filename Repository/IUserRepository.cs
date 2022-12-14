using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(int userId);
        UserDTOUpdate AddUser(UserDTOAdd user);
        UserDTOUpdate UpdateUser(User user, int userId);
        void DeleteUser(int userId);
    }
}