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
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<DispatchDetailsRepository>().As<IDispatchDetailsRepository>();
            builder.RegisterType<PlantRepository>().As<IPlantRepository>();
            builder.RegisterType<PriceDetailsRepository>().As<IPriceDetailsRepository>();
            builder.RegisterType<ProductionDetailsRepository>().As<IProductionDetailsRepository>();
            builder.RegisterType<RawMaterialConsumptionRepository>().As<IRawMaterialConsumptionRepository>();
            builder.RegisterType<RawMaterialDetailsRepository>().As<IRawMaterialDetailsRepository>();
            builder.RegisterType<RawMaterialInwardRepository>().As<IRawMaterialInwardRepository>();
            builder.RegisterType<SizeDetailsRepository>().As<ISizeDetailsRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<TenantRepository>().As<ITenantRepository>();
        }

    }
}
