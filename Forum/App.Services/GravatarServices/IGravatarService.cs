namespace App.Services.GravatarServices
{
    public interface IGravatarService
    {
        string GetGravatarHash(string userEMail);
    }
}
