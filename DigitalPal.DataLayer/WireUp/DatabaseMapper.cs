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
            builder.RegisterType<DispatchDetailsDA>().As<IDispatchDetailsDA>().InstancePerRequest();
            builder.RegisterType<CustomerDA>().As<ICustomerDA>().InstancePerRequest();
            builder.RegisterType<PlantDA>().As<IPlantDA>().InstancePerRequest();
            builder.RegisterType<PriceDetailsDA>().As<IPriceDetailsDA>().InstancePerRequest();
            builder.RegisterType<ProductionDetailsDA>().As<IProductionDetailsDA>().InstancePerRequest();
            builder.RegisterType<RawMaterialConsumptionDA>().As<IRawMaterialConsumptionDA>().InstancePerRequest();
            builder.RegisterType<RawMaterialDetailsDA>().As<IRawMaterialDetailsDA>().InstancePerRequest();
            builder.RegisterType<RawMaterialInwardDA>().As<IRawMaterialInwardDA>().InstancePerRequest();
            builder.RegisterType<SizeDetailsDA>().As<ISizeDetailsDA>().InstancePerRequest();
            builder.RegisterType<SupplierDA>().As<ISupplierDA>().InstancePerRequest();

            builder.RegisterType<DispatchDA>().As<IDispatchDA>();
            builder.RegisterType<InvoiceDA>().As<IInvoiceDA>();
            builder.RegisterType<PaymentDA>().As<IPaymentDA>();
            builder.RegisterType<SupplierPaymentDA>().As<ISupplierPaymentDA>();
            builder.RegisterType<ProductDA>().As<IProductDA>();
            builder.RegisterType<OrderDA>().As<IOrderDA>();
            builder.RegisterType<OrderDetailsDA>().As<IOrderDetailsDA>();
            builder.RegisterType<SupplierOrderDA>().As<ISupplierOrderDA>();
            builder.RegisterType<SupplierOrderDetailsDA>().As<ISupplierOrderDetailsDA>();
            builder.RegisterType<ProductionDA>().As<IProductionDA>().InstancePerRequest();
        }
        private void RegisterConnectionString(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDatabaseSettings>().As<ISqlDatabaseSettings>().InstancePerLifetimeScope();
        }
    }
}
