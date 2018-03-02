using System.ComponentModel.DataAnnotations;

namespace App.MVC.ViewModels.Registration
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "User name field cannot be empty")]
        [MaxLength(20, ErrorMessage = "User name cannot be longer than 20 chars")]
        [MinLength(3, ErrorMessage = "User name cannot be shorter than 3 chars")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Mail field cannot be empty")]
        [EmailAddress(ErrorMessage = "E-Mail invalid format")]
        public string EMail { get; set; }

        [Compare("EMail", ErrorMessage = "E-Mail and Confirm E-Mail fields must be the same")]
        public string ConfirmEMail { get; set; }

        [Required(ErrorMessage = "Password field cannot be empty")]
        [MaxLength(100, ErrorMessage = "Password cannot be longer than 100 chars")]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 chars")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password fields must be the same")]
        public string ConfirmPassword { get; set; }
    }
}