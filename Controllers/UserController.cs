using Microsoft.AspNetCore.Mvc;
using geo_pet.Repository;
using geo_pet.Models;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller 
    {
        private readonly IUserReporitory _repository;
        public UserController(IUserReporitory repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_repository.GetUsers());
        }
    }
}