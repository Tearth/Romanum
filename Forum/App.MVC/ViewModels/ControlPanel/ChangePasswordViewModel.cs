using System.ComponentModel.DataAnnotations;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Password cannot be longer than 100 chars")]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 chars")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm New Password fields must be the same")]
        public string ConfirmNewPassword { get; set; }
    }
}