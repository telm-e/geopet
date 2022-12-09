using Microsoft.AspNetCore.Mvc;
using geo_pet.Repository;
using geo_pet.Models;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller 
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
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
        public IActionResult Add([FromBody] User user)
        {
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