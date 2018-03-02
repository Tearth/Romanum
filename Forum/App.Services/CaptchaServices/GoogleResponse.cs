using System;

namespace App.Services.CaptchaServices
{
    public class GoogleResponse
    {
        public bool Success { get; set; }
        public DateTime Challenge_ts { get; set; }
        public string Hostname { get; set; }
    }
}
