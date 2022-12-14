using Microsoft.EntityFrameworkCore;
using geo_pet.Models;
using geo_pet.Repository;
using FluentAssertions;

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
        Helpers.GetContextInstanceForTests("ShouldGetVideoById"),
        1,
        new Video {
            VideoId = 1,
            Title = "Video 1",
            ChannelId = 1,
            Description = "Test",
            Url = "Test"
        }
      },
      };
