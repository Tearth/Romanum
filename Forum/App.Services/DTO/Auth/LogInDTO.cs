namespace App.Services.DTO.Auth
{
    public class LogInDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
