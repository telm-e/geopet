using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace geo_pet.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Size { get; set; }
        public string Breed { get; set; }
        public string Hash { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    public class PetDTO
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public string Breed { get; set; }
        public string Hash { get; set; }
        public int UserId { get; set; }

    }

        public class PetDTOUser
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Size { get; set; }
        public string Breed { get; set; }
        public string Hash { get; set; }

    }

    public class PetInsert
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Size { get; set; }
        public string Breed { get; set; }
        public string Hash { get; set; }
        public int UserId { get; set; }
    }
}