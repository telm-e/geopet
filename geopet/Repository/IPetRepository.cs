using geo_pet.Models;

namespace geo_pet.Repository
{
    public interface IPetRepository
    {
        IEnumerable<PetDTO> GetPets();
        object GetPetById (int PetId);
        object AddPet (PetInsert pet);
        object UpdatedPet (PetInsert pet, int PetId);
        void DeletePet(int id);
    }
}