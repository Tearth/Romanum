namespace Business.Services.ConfigServices
{
    public interface IConfigService
    {
        T GetValue<T>(string key);
        void CreateOrUpdateKey<T>(string key, T value);

        bool KeyExists(string key);
        void RemoveKey(string key);
    }
}
