using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace App.MVC.App_Start
{
    class MapperConfig
    {
        internal static void RegisterProfiles()
        {
            //AutoMapper will cause MissingMethodException when
            //trying to pass to AddProfiles, so get all assemblies
            //without this library
            var assemblies = AppDomain.CurrentDomain
                                      .GetAssemblies()
                                      .Where(q => q.GetName().Name != "AutoMapper");

            Mapper.Initialize(p => p.AddProfiles(assemblies));
        }
    }
}