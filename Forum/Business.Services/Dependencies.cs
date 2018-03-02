using Autofac;
using Business.Services.Helpers.Time;

namespace Business.Services
{
    public class Dependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(p => p.IsSubclassOf(typeof(ServiceBase)))
                .AsImplementedInterfaces();

            builder.RegisterType<TimeProvider>().As<ITimeProvider>();

            base.Load(builder);
        }
    }
}
