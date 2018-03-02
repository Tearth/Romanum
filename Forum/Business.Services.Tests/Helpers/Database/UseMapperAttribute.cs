using System;
using AutoMapper;
using Xunit.Sdk;

namespace Business.Services.Tests.Helpers.Database
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UseMapperAttribute : BeforeAfterTestAttribute
    {
        private static bool Ready;

        public UseMapperAttribute()
        {
            if (!Ready)
            {
                Mapper.Initialize(config =>
                    config.AddProfile(new MapperProfile()));

                Ready = true;
            }
        }
    }
}
