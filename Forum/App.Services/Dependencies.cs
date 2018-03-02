using Autofac;

namespace App.Services
{
    public class Dependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(p => p.IsSubclassOf(typeof(ServiceBase)))
                   .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
