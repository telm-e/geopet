using System.Collections.ObjectModel;
using geo_pet.Models;
using geo_pet.Repository;
namespace geo_pet.Test;

public class UserRepositoryTest
{
    [Theory]
    [MemberData(nameof(ShouldGetUserByIdData))]
    public void ShouldGetUserById(GeoPetContext context, int userId, UserDTO userExpected)
    {
        // Arrange
        var repository = new UserRepository(context);

        // Act
        UserDTO userById = repository.GetUserById(userId);

        // Assert
        userById.Should().BeEquivalentTo(userExpected);
    }
    public readonly static TheoryData<GeoPetContext, int, UserDTO> ShouldGetUserByIdData =
      new()
      {
        {
          Helpers.GetContextInstanceForTests("ShouldGetUserById"),
          1,
          new UserDTO() {
              Name = "Telme",
              Email = "falecomtelme@gmail.com",
              Phone = "31999999999",
              Cep = "30140903",
              Pets = new Collection<PetDTOUser>() {
                new PetDTOUser() {
                PetId = 1,
                Name = "Varda",
                Age = 1,
                Size = "medium",
                Breed = "mixed",
                Hash = "78fHFDS830",
                },
              }
          }
        },
      };

      [Theory]
    [MemberData(nameof(ShouldGetUsersData))]
    public void ShouldGetUsers(GeoPetContext context, IEnumerable<UserDTO> usersExpected)
    {
        // Arrange
        var repository = new UserRepository(context);

        // Act
        IEnumerable<UserDTO> users = repository.GetUsers();

        // Assert
        users.Should().BeEquivalentTo(usersExpected);
    }
    public readonly static TheoryData<GeoPetContext, IEnumerable<UserDTO>> ShouldGetUsersData =
      new()
      {
        {
          Helpers.GetContextInstanceForTests("ShouldGetUsers"),
          new Collection<UserDTO>() {
              new UserDTO() {
                Name = "Telme",
                Email = "falecomtelme@gmail.com",
                Phone = "31999999999",
                Cep = "30140903",
                Pets = new Collection<PetDTOUser>() {
                  new PetDTOUser() {
                  PetId = 1,
                  Name = "Varda",
                  Age = 1,
                  Size = "medium",
                  Breed = "mixed",
                  Hash = "78fHFDS830",
                  },
                }
              },
              new UserDTO() {
                Name = "Gabriel",
                Email = "gabriel@exemplo.com",
                Phone = "31999999999",
                Cep = "30140903",
                Pets = new Collection<PetDTOUser>() {
                  new PetDTOUser() {
                  PetId = 2,
                  Name = "Paçoca",
                  Age = 1,
                  Size = "medium",
                  Breed = "mixed",
                  Hash = "67fHFDS830",
                  },
                  new PetDTOUser() {
                  PetId = 3,
                  Name = "Favela",
                  Age = 2,
                  Size = "medium",
                  Breed = "mixed",
                  Hash = "13fHFDS830",
                  },
                }
              }
            }
        },
      };
}
