using System.ComponentModel.DataAnnotations;

namespace App.MVC.ViewModels.LogIn
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "User name cannot be empty")]
        [MaxLength(20, ErrorMessage = "User name cannot be longer than 20 chars")]
        [MinLength(3, ErrorMessage = "User name cannot be shorter than 3 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [MaxLength(100, ErrorMessage = "Password cannot be longer than 100 chars")]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 chars")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}