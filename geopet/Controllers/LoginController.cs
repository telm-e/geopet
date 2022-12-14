using Microsoft.AspNetCore.Mvc;
using geo_pet.Repository;
using geo_pet.Models;
using geo_pet.Services;

namespace geo_pet.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller 
    {
        private readonly ILoginRepository _repository;
        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]

        public ActionResult<LoginDTO> Authenticate([FromBody] Login user)
        {
        LoginDTO userLogin = new LoginDTO();
        try
        {
            userLogin.User = _repository.GetUserByEmail(user.Email);

            if (userLogin.User == null)
            {
            return NotFound("User not found!");
            }

            if (user.Password != userLogin.User.Password)
            {
            return Unauthorized("Wrong password!");
            }

            userLogin.Token = new TokenGenerator().Generate();

            userLogin.User.Password = string.Empty;
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return userLogin;
        }
        
    }
}