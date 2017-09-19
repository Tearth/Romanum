using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.CaptchaService
{
    public interface ICaptchaService
    {
        bool Verify(string sercretCode, string responseCode);
    }
}
