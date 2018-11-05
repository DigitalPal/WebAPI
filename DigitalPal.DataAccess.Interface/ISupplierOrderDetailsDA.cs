using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface ISupplierOrderDetailsDA
    {
        Task AddSupplierOrderDetailsAsync(SupplierOrderDetails[] SupplierOrderDetails);
        SupplierOrderDetails[] AddSupplierOrderDetails(SupplierOrderDetails[] SupplierOrderDetails);

        SupplierOrderDetails GetSupplierOrderDetails(string id);

        Dictionary<string, SupplierOrderDetails> GetSupplierOrderDetails(string[] ids);

        SupplierOrderDetails[] GetSupplierOrderDetails(IEnumerable<Guid?> ids);

        SupplierOrderDetails[] GetAll();

        SupplierOrderDetails[] GetByIds(IEnumerable<Guid> Ids);

        SupplierOrderDetails[] UpdateSupplierOrderDetails(SupplierOrderDetails[] SupplierOrderDetails);

        SupplierOrderDetails[] DeleteSupplierOrderDetails(string id);

        void DeleteSupplierOrderDetailsBySupplierOrderId(string id);
    }
}
