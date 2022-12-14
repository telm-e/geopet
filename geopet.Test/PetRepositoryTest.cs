using System.Collections.ObjectModel;
using geo_pet.Models;
using geo_pet.Repository;
namespace geo_pet.Test;

public class PetRepositoryTest
{
    [Theory]
    [MemberData(nameof(ShouldGetPetByIdData))]
    public void ShouldGetPetById(GeoPetContext context, int petId, PetDTO petExpected)
    {
        // Arrange
        var repository = new PetRepository(context);

        // Act
        var petById = repository.GetPetById(petId);

        // Assert
        petById.Should().BeEquivalentTo(petExpected);
    }
    public readonly static TheoryData<GeoPetContext, int, PetDTO> ShouldGetPetByIdData =
      new()
      {
        {
          Helpers.GetContextInstanceForTests("ShouldGetPetByIdData"),
          1,
          new PetDTO() {
            PetId = 1,
            Name = "Varda",
            Age = 1,
            Size = "medium",
            Breed = "mixed",
            Hash = "78fHFDS830",
            UserId = 1,
          }
        },
      };

    [Theory]
    [MemberData(nameof(ShouldGetPetData))]
    public void ShouldGetPets(GeoPetContext context, IEnumerable<PetDTO> petsExpected)
    {
        // Arrange
        var repository = new PetRepository(context);

        // Act
        IEnumerable<PetDTO> pets = repository.GetPets();

        // Assert
        pets.Should().BeEquivalentTo(petsExpected);
    }
    public readonly static TheoryData<GeoPetContext, IEnumerable<PetDTO>> ShouldGetPetData =
      new()
      {
        {
          Helpers.GetContextInstanceForTests("ShouldGetPetData"),
          new Collection<PetDTO>() {
              new PetDTO() {
                PetId = 1,
                Name = "Varda",
                Age = 1,
                Size = "medium",
                Breed = "mixed",
                Hash = "78fHFDS830",
                UserId = 1,
              },
               new PetDTO() {
                PetId = 2,
                Name = "Paçoca",
                Age = 1,
                Size = "medium",
                Breed = "mixed",
                Hash = "67fHFDS830",
                UserId = 2,
              },
               new PetDTO() {
                PetId = 3,
                Name = "Favela",
                Age = 2,
                Size = "medium",
                Breed = "mixed",
                Hash = "13fHFDS830",
                UserId = 2,
              },
            }
        },
      };

    [Theory]
    [MemberData(nameof(ShouldDeletePetData))]
    public void ShouldDeletePet(GeoPetContext context, int petId, IEnumerable<PetDTO> petsExpected)
    {
        // Arrange
        var repository = new PetRepository(context);

        // Act
        repository.DeletePet(petId);

        // Assert
        repository.GetPets().Should().BeEquivalentTo(petsExpected);
    }

    public readonly static TheoryData<GeoPetContext, int, IEnumerable<PetDTO>> ShouldDeletePetData =
      new()
      {
        {
          Helpers.GetContextInstanceForTests("ShouldDeletePetData"),
          3,
          new Collection<PetDTO>() {
              new PetDTO() {
                PetId = 1,
                Name = "Varda",
                Age = 1,
                Size = "medium",
                Breed = "mixed",
                Hash = "78fHFDS830",
                UserId = 1,
              },
               new PetDTO() {
                PetId = 2,
                Name = "Paçoca",
                Age = 1,
                Size = "medium",
                Breed = "mixed",
                Hash = "67fHFDS830",
                UserId = 2,
              },
            }
        },
      };
}