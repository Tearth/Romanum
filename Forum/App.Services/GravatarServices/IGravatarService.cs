﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.GravatarServices
{
    public interface IGravatarService
    {
        string GetGravatarHash(string userEMail);
    }
}
