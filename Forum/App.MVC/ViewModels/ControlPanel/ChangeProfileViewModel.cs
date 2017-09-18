using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ChangeProfileViewModel
    {
        [Required(ErrorMessage = "E-Mail field cannot be empty")]
        [EmailAddress(ErrorMessage = "E-Mail invalid format")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "City field cannot be empty")]
        public string City { get; set; }

        [Required(ErrorMessage = "About field cannot be empty")]
        public string About { get; set; }

        [Required(ErrorMessage = "Footer field cannot be empty")]
        public string Footer { get; set; }
    }
}