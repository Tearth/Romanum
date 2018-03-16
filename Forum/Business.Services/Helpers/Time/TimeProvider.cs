using System;

namespace Business.Services.Helpers.Time
{
    /// <summary>
    /// Represents a set of methods to manage time.
    /// </summary>
    public class TimeProvider : ITimeProvider
    {
        /// <inheritdoc />
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
