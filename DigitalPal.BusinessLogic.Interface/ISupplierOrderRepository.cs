using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface ISupplierOrderRepository
    {
        Task AddSupplierOrderAsync(SupplierOrder[] SupplierOrders);
        SupplierOrder[] AddSupplierOrders(SupplierOrder[] SupplierOrders);
        SupplierOrder[] Search(SupplierOrder SupplierOrder);
        SupplierOrder GetSupplierOrder(string id);

        SupplierOrder GetSupplierOrderInformation(string id);
        Dictionary<string, string> GetMaxNumber();

        Dictionary<string, SupplierOrder> GetSupplierOrders(string[] ids);

        SupplierOrder[] GetSupplierOrders(IEnumerable<Guid?> ids);

        SupplierOrder[] GetAll();

        SupplierOrder[] GetByIds(IEnumerable<Guid> Ids);

        SupplierOrder[] UpdateSupplierOrders(SupplierOrder[] SupplierOrders);

        SupplierOrder DeleteSupplierOrders(string id);
    }
}
