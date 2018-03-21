using System.ComponentModel.DataAnnotations;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ChangeProfileViewModel
    {
        [Required(ErrorMessage = "E-Mail field cannot be empty")]
        [EmailAddress(ErrorMessage = "E-Mail invalid format")]
        public string EMail { get; set; }

        public string City { get; set; }
        public string About { get; set; }
        public string Footer { get; set; }
    }
}