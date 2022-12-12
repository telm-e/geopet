using Microsoft.AspNetCore.Mvc;
using geo_pet.Repository;
using geo_pet.Models;
using geo_pet.services.interfaces;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller 
    {
        private readonly IUserRepository _repository;
        private readonly ICepService _cepService;
        public UserController(IUserRepository repository, ICepService cepService)
        {
            _repository = repository;
            _cepService = cepService;
        }

        
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            return Ok(_repository.GetUserById(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            var cep = user.Cep;
            var validateCep = await _cepService.GetCep(cep);
            if (validateCep.ToString().Contains("erro"))
            {
                return BadRequest("Cep inválido, digite um cep válido e que contenha 8 digitos");
            }

            return Created("",_repository.AddUser(user));      
        }

        [HttpPut("{userId}")]
        public IActionResult Update([FromBody] User user, int userId)
        {
            return Ok(_repository.UpdateUser(user, userId));
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            _repository.DeleteUser(userId);
            return Ok(new { message= "Removido com sucesso"});
        }
    }
}