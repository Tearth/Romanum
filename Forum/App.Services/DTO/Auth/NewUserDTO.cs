using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.DTO.Auth
{
    public class NewUserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
    }
}
