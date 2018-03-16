using System;

namespace Business.Services.Helpers.Time
{
    /// <summary>
    /// Represents an interface for time provider.
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>The current time.</returns>
        DateTime Now();
    }
}
