namespace App.Services.CaptchaServices
{
    /// <summary>
    /// Represents an interface for Google captcha service.
    /// </summary>
    public interface ICaptchaService
    {
        /// <summary>
        /// Verifies captcha parameters in Google service.
        /// </summary>
        /// <param name="secretCode">The secret key specified for the Web application.</param>
        /// <param name="responseCode">The response code received from user.</param>
        /// <returns>True if the captcha parameters are valid and request can be continued, otherwise false.</returns>
        bool Verify(string secretCode, string responseCode);
    }
}
