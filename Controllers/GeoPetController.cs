using Microsoft.AspNetCore.Mvc;
using geo_pet.Repository;
using geo_pet.Models;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("users")]
    public class GeoPetController : Controller 
    {
        private readonly IGeoPetRepository _repository;
        public GeoPetController(IGeoPetRepository repository)
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