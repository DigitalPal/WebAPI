using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface ISupplierOrderDA
    {
        Task AddSupplierOrderAsync(SupplierOrder[] SupplierOrder);
        SupplierOrder[] AddSupplierOrder(SupplierOrder[] SupplierOrder);
        SupplierOrder[] Search(SupplierOrder SupplierOrder);
        SupplierOrder GetSupplierOrder(string id);

        SupplierOrder GetSupplierOrderInformation(string id);
        Dictionary<string, string> GetMaxNumber();
        Dictionary<string, SupplierOrder> GetSupplierOrder(string[] ids);

        SupplierOrder[] GetSupplierOrder(IEnumerable<Guid?> ids);

        SupplierOrder[] GetAll();

        SupplierOrder[] GetByIds(IEnumerable<Guid> Ids);

        SupplierOrder[] UpdateSupplierOrder(SupplierOrder[] SupplierOrder);

        SupplierOrder DeleteSupplierOrder(string id);
    }
}
