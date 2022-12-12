using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geo_pet.Models;
using geo_pet.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _repository;
        public PetController(IPetRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetPets());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetPetById(int PetId)
        {
            return Ok(_repository.GetPetById(PetId));
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPet([FromBody] PetInsert pet)
        {
            return Created("", _repository.AddPet(pet));
        }

        [HttpPut("{petId}")]
        [Authorize]
        public IActionResult Update([FromBody] PetInsert pet, int petId)
        {
            var response = _repository.UpdatedPet(pet, petId);
            if(response == null)
            {
                return NotFound("Pet Not Found");
            }
            return Ok(response);
        }

        [HttpDelete("{petId}")]
        [Authorize]
        public IActionResult DeletePet(int petId)
        {
            _repository.DeletePet(petId);
            return Ok(new { message= "Removido com sucesso"});
        }
    }
}