using Business.Services.ConfigServices.Exceptions;

namespace Business.Services.ConfigServices
{
    /// <summary>
    /// Represents an interface for configuration service.
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// Gets the value associated with the specified key and converts it to the type T.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="key">The key name.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the specified key doesn't exists.</exception>
        /// <returns>The key value.</returns>
        T GetValue<T>(string key);

        /// <summary>
        /// Creates (if not exists) or updates the specified key.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="key">The key name.</param>
        /// <param name="value">The new value of the specified key.</param>
        void CreateOrUpdateKey<T>(string key, T value);

        /// <summary>
        /// Checks if the specified key exists.
        /// </summary>
        /// <param name="key">The key name.</param>
        /// <returns>True if the specified key exists, otherwise false.</returns>
        bool KeyExists(string key);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Thrown when the specified key doesn't exists.</exception>
        /// <param name="key">The key name.</param>
        void RemoveKey(string key);
    }
}
