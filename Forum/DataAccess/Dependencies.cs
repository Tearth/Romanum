using Autofac;
using DataAccess.Database;

namespace DataAccess
{
    public class Dependencies : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>()
                .WithParameter("connectionStringName", "MainDB");

            base.Load(builder);
        }
    }
}
