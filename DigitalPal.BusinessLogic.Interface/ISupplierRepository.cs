using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface ISupplierRepository
    {
        Task AddSupplierAsync(Supplier[] Suppliers);
        Supplier[] AddSuppliers(Supplier[] Suppliers);

        Supplier GetSupplier(string id);

        Dictionary<string, Supplier> GetSuppliers(string[] ids);

        Supplier[] GetSuppliers(IEnumerable<Guid?> ids);

        Supplier[] GetAll();

        Supplier[] GetByIds(IEnumerable<Guid> Ids);

        Supplier[] UpdateSuppliers(Supplier[] Suppliers);

        Supplier[] DeleteSuppliers(Supplier[] Suppliers);
    }
}
