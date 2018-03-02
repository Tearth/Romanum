namespace App.Services.CaptchaServices
{
    public interface ICaptchaService
    {
        bool Verify(string sercretCode, string responseCode);
    }
}
