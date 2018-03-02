using System;

namespace Business.Services.Helpers.Time
{
    public interface ITimeProvider
    {
        DateTime Now();
    }
}
