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
}
