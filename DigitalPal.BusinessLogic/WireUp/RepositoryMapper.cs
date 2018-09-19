using Autofac;
using Autofac.Extras.DynamicProxy;
using DigitalPal.BusinessLogic.Interface;

namespace DigitalPal.BusinessLogic.WireUp
{
    public class RepositoryMapper: Module
    {
        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TenantRepository>().As<ITenantRepository>();
        }

    }
}
