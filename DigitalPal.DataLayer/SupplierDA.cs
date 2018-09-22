using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class SupplierDA : DataAccessBase<Supplier>, ISupplierDA
    {

        public SupplierDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Supplier;
        }

        public async Task AddSupplierAsync(Supplier[] Suppliers)
        {
            await base.AddAsync(Suppliers);
        }

        public Supplier[] AddSuppliers(Supplier[] Suppliers)
        {
            return base.Add(Suppliers);
        }

        public Supplier GetSupplier(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Supplier> GetSuppliers(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Supplier[] GetSuppliers(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Supplier[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Supplier[] GetByIds(IEnumerable<Guid> Ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsActive = 1", GetTableName());
            return base.FindByTempTableIds(sql, Ids).ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Supplier()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Supplier item)
        {
            return new
            {
                item.Id,
                item.SupplierName,
                item.Description,
                item.GSTNumber,
                item.IsActive,
                item.Type,
                item.CreatedOn,
                item.ModifiedOn,
                item.Address,
                item.SupplierNumber,
                item.ContactNumber,
                item.CreatedBy,
                item.ModifiedBy
            };
        }

        public Supplier[] UpdateSuppliers(Supplier[] Suppliers)
        {
            if (Suppliers.Any())
            {
                base.Update(Suppliers);
            }

            return Suppliers;
        }

        public Supplier[] DeleteSuppliers(Supplier[] Suppliers)
        {
            if (Suppliers.Any())
            {
                base.DeleteByDbId(Suppliers.Select(x => x.Id.ToString()).ToArray());
            }

            return Suppliers;
        }
    }
}
