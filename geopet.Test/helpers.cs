using Microsoft.EntityFrameworkCore;
using geo_pet.Models;
using geo_pet.Repository;
using System.Globalization;

namespace geo_pet.Test
{
    public static class Helpers
    {
        public static GeoPetContext GetContextInstanceForTests(string inMemoryDbName)
        {
            var contextOptions = new DbContextOptionsBuilder<GeoPetContext>()
                .UseInMemoryDatabase(inMemoryDbName)
                .Options;
            var context = new GeoPetContext(contextOptions);
            context.Users.AddRange(
                GetUserListForTests()
            );
            context.Pets.AddRange(
                GetPetsListForTests()
            );
            context.SaveChanges();
            return context;
        }

        public static List<User> GetUserListForTests() =>
            new() {
                new User{
                    UserId = 1,
                    Name = "Telme",
                    Email = "falecomtelme@gmail.com",
                    Phone = "31999999999",
                    Cep = "30140903",
                    Password = "agnesvarda"
                },
                new User{
                    UserId = 2,
                    Name = "Gabriel",
                    Email = "gabriel@exemplo.com",
                    Phone = "31999999999",
                    Cep = "30140903",
                    Password = "cruzeiro"
                },
            };

        public static List<Pet> GetPetsListForTests()
        {
            var data1 = new DateTime(2021, 8, 23);
            var data2 = new DateTime(2021, 8, 10);
            var data3 = new DateTime(2020, 1, 13);
            return new() {
                new Pet {
                    PetId = 1,
                    Name = "Varda",
                    Birth = data1,
                    Size = "medium",
                    Breed = "mixed",
                    Hash = "78fHFDS830",
                    UserId = 1,
                },
                new Pet {
                    PetId = 2,
                    Name = "Paçoca",
                    Birth = data2,
                    Size = "medium",
                    Breed = "mixed",
                    Hash = "67fHFDS830",
                    UserId = 2,
                },
                new Pet {
                    PetId = 3,
                    Name = "Favela",
                    Birth = data3,
                    Size = "medium",
                    Breed = "mixed",
                    Hash = "13fHFDS830",
                    UserId = 2,
                },
            };
        }
    }
}