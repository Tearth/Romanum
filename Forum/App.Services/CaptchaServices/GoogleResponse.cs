using System;

namespace App.Services.CaptchaServices
{
    /// <summary>
    /// Represents a Google captcha response received from external service.
    /// </summary>
    public class GoogleResponse
    {
        /// <summary>
        /// Gets or sets the flag indicates whether the captcha parameters were valid or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the time when the request has been made.
        /// </summary>
        public DateTime Challenge_ts { get; set; }

        /// <summary>
        /// Gets or sets the hostname which has sent the request.
        /// </summary>
        public string Hostname { get; set; }
    }
}
