using System;
using System.Linq;
using AutoMapper;

namespace App.MVC
{
    internal class MapperConfig
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