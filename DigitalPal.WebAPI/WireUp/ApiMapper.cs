using Autofac;
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
            builder.RegisterType<PlantController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.PlantRepository = e.Context.Resolve<IPlantRepository>();
            });
            builder.RegisterType<DispatchController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.DispatchRepository = e.Context.Resolve<IDispatchRepository>();
            });
            builder.RegisterType<PriceDetailsController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.PriceDetailsRepository = e.Context.Resolve<IPriceDetailsRepository>();
            });
            builder.RegisterType<ProductionDetailsController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ProductionDetailsRepository = e.Context.Resolve<IProductionDetailsRepository>();
            });
            builder.RegisterType<RawMaterialConsumptionController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.RawMaterialConsumptionRepository = e.Context.Resolve<IRawMaterialConsumptionRepository>();
            });
            builder.RegisterType<RawMaterialDetailsController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.RawMaterialDetailsRepository = e.Context.Resolve<IRawMaterialDetailsRepository>();
            });
            builder.RegisterType<RawMaterialInwardController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.RawMaterialInwardRepository = e.Context.Resolve<IRawMaterialInwardRepository>();
            });
            builder.RegisterType<SizeDetailsController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.SizeDetailsRepository = e.Context.Resolve<ISizeDetailsRepository>();
            });
            builder.RegisterType<SupplierController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.SupplierRepository = e.Context.Resolve<ISupplierRepository>();
            });
            builder.RegisterType<CustomerController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.CustomerRepository = e.Context.Resolve<ICustomerRepository>();
            });

            builder.RegisterType<InvoiceController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.InvoiceRepository = e.Context.Resolve<IInvoiceRepository>();
            });
            builder.RegisterType<PaymentController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.PaymentRepository = e.Context.Resolve<IPaymentRepository>();
            });
            builder.RegisterType<SupplierPaymentController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.SupplierPaymentRepository = e.Context.Resolve<ISupplierPaymentRepository>();
            });
            builder.RegisterType<OrderController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.OrderRepository = e.Context.Resolve<IOrderRepository>();
            });
            builder.RegisterType<SupplierOrderController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.SupplierOrderRepository = e.Context.Resolve<ISupplierOrderRepository>();
            });
            builder.RegisterType<ProductController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ProductRepository = e.Context.Resolve<IProductRepository>();
            });
            builder.RegisterType<ProductionController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ProductionRepository = e.Context.Resolve<IProductionRepository>();
            });
            builder.RegisterType<ConsumptionController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ConsumptionRepository = e.Context.Resolve<IConsumptionRepository>();
            });
        }
    }
}