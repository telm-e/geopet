using geo_pet.Models;

namespace geo_pet.Repository
{
  public class PetRepository : IPetRepository
  {
    protected readonly GeoPetContext _context;
    public PetRepository(GeoPetContext context)
    {
      _context = context;
    }


    public IEnumerable<PetDTO> GetPets()
    {
      var pets = _context.Pets
      .Select(x => new PetDTO
      {
        PetId = x.PetId,
        Name = x.Name,
        Age = x.Age,
        Size = x.Size,
        Breed = x.Breed,
        Hash = x.Hash
      });
      return pets;
    }

    public object GetPetById(int PetId)
    {
      var petById = _context.Pets
      .Where(x => x.PetId == PetId)
      .Select(x => new PetDTO
      {
        PetId = x.PetId,
        Name = x.Name,
        Age = x.Age,
        Size = x.Size,
        Breed = x.Breed,
        Hash = x.Hash
      }).First();
      return petById;
    }
    public object AddPet(PetInsert pet)
    {
      var newPet = new Pet
      {
        Name = pet.Name,
        Age = pet.Age,
        Size = pet.Size,
        Breed = pet.Breed,
        Hash = pet.Hash,
      };
      _context.Pets.Add(newPet);
      _context.SaveChanges();

      var result = GetPetById(newPet.PetId);
      return result;
    }

    public object UpdatedPet(PetInsert pet, int petId)
    {
      var MyPet = _context.Pets.Find(petId);
      if (MyPet != null)
      {
        MyPet.Name = pet.Name;
        MyPet.Age = pet.Age;
        MyPet.Size = pet.Size;
        MyPet.Breed = pet.Breed;
        MyPet.Hash = pet.Hash;
        _context.SaveChanges();
        var result = GetPetById(petId);
        return result;
      }
      throw new ArgumentException("Pet Not Found");
    }


    public void DeletePet(int petId)
    {
      var pet = _context.Pets.Find(petId);
      if (pet != null)
      {
        _context.Pets.Remove(pet);
        _context.SaveChanges();
      }
      throw new ArgumentException("Pet Not Found");

    }
  }
}