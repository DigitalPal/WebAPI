using Autofac;
using Autofac.Extras.DynamicProxy;
using DigitalPal.BusinessLogic.Interface;
using DigitalPal.WebAPI.Controllers;

namespace DigitalPal.WebAPI.WireUp
{
    public class ApiMapper : Module
    {

        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TenantController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.tenantRepository = e.Context.Resolve<ITenantRepository>();
            });
        }
    }
}