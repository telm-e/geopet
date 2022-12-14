namespace geo_pet.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTO
    {
        public Login User { get; set; }
        public string Token { get; set; }
    }
}