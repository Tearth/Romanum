using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Business.Services.Tests.Helpers.Database
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UseMapperAttribute : BeforeAfterTestAttribute
    {
        static bool Ready = false;

        public UseMapperAttribute()
        {
            if (!Ready)
            {
                Mapper.Initialize(config => 
                    config.AddProfile(new Business.Services.MapperProfile()));

                Ready = true;
            }    
        }
    }
}
