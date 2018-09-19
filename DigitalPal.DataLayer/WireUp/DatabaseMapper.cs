using Autofac;
using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;

namespace DigitalPal.DataAccess.WireUp
{
    public class DatabaseMapper : Module
    {
        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            RegisterConnectionString(builder);
            builder.RegisterType<TenantDA>().As<ITenantDA>().InstancePerRequest();
        }
        private void RegisterConnectionString(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDatabaseSettings>().As<ISqlDatabaseSettings>().InstancePerLifetimeScope();
        }
    }
}
