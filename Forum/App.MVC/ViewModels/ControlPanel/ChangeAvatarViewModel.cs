using System.Collections.Generic;
using System.Web;
using App.MVC.ViewModels.ControlPanel.Enums;

namespace App.MVC.ViewModels.ControlPanel
{
    public class ChangeAvatarViewModel
    {
        public AvatarType Type { get; set; }
        public string Source { get; set; }
        public HttpPostedFileBase AvatarFile { get; set; }
    }
}