using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ChangeProfileViewModel
    {
        public string EMail { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string Footer { get; set; }
    }
}