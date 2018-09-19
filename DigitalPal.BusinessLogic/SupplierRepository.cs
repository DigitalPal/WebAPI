using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class SupplierRepository : ISupplierRepository
    {
        private ISupplierDA _SupplierDA;

        public SupplierRepository(ISupplierDA SupplierDA)
        {
            _SupplierDA = SupplierDA;
        }

        public async Task AddSupplierAsync(Supplier[] Suppliers)
        {
            await _SupplierDA.AddSupplierAsync(Suppliers);
        }
        public Supplier[] AddSuppliers(Supplier[] Suppliers)
        {
            return _SupplierDA.AddSuppliers(Suppliers);
        }

        public Supplier GetSupplier(string id)
        {
            return _SupplierDA.GetSupplier(id);
        }

        public Dictionary<string, Supplier> GetSuppliers(string[] ids)
        {
            return _SupplierDA.GetSuppliers(ids);
        }

        public Supplier[] GetSuppliers(IEnumerable<Guid?> ids)
        {
            return _SupplierDA.GetSuppliers(ids);
        }

        public Supplier[] GetAll()
        {
            return _SupplierDA.GetAll();
        }


        public Supplier[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _SupplierDA.GetByIds(Ids);
        }

        public Supplier[] UpdateSuppliers(Supplier[] Suppliers)
        {
            return _SupplierDA.UpdateSuppliers(Suppliers);
        }

        public Supplier[] DeleteSuppliers(Supplier[] Suppliers)
        {
            return _SupplierDA.DeleteSuppliers(Suppliers);
        }
    }
}
