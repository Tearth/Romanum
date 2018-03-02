namespace App.Services.DTO.Auth
{
    public class ChangePasswordDTO
    {
        public string Name { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
