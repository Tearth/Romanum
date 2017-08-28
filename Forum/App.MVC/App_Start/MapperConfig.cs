using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace App.MVC.App_Start
{
    internal class MapperConfig
    {
        public static void RegisterProfiles()
        {
            //Make sure that all necessary assemblies are loaded
            App.Services.Bootloader.Init();
            Business.Services.Bootloader.Init();

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