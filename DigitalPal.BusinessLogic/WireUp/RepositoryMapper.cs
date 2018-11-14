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
            builder.RegisterType<DispatchRepository>().As<IDispatchRepository>();
            builder.RegisterType<PlantRepository>().As<IPlantRepository>();
            builder.RegisterType<PriceDetailsRepository>().As<IPriceDetailsRepository>();
            builder.RegisterType<ProductionDetailsRepository>().As<IProductionDetailsRepository>();
            builder.RegisterType<RawMaterialConsumptionRepository>().As<IRawMaterialConsumptionRepository>();
            builder.RegisterType<RawMaterialDetailsRepository>().As<IRawMaterialDetailsRepository>();
            builder.RegisterType<RawMaterialInwardRepository>().As<IRawMaterialInwardRepository>();
            builder.RegisterType<SizeDetailsRepository>().As<ISizeDetailsRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<TenantRepository>().As<ITenantRepository>();
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>();
            builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();
            builder.RegisterType<SupplierPaymentRepository>().As<ISupplierPaymentRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<SupplierOrderRepository>().As<ISupplierOrderRepository>();
            builder.RegisterType<ProductionRepository>().As<IProductionRepository>();
        }

    }
}
