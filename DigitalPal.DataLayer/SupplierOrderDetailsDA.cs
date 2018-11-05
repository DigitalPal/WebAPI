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
    public class SupplierOrderDetailsDA : DataAccessBase<SupplierOrderDetails>, ISupplierOrderDetailsDA
    {

        public SupplierOrderDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_SupplierOrderDetails;
        }

        public async Task AddSupplierOrderDetailsAsync(SupplierOrderDetails[] SupplierOrderDetails)
        {
            await base.AddAsync(SupplierOrderDetails);
        }

        public SupplierOrderDetails[] AddSupplierOrderDetails(SupplierOrderDetails[] SupplierOrderDetails)
        {
            return base.Add(SupplierOrderDetails);
        }

        public SupplierOrderDetails GetSupplierOrderDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, SupplierOrderDetails> GetSupplierOrderDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public SupplierOrderDetails[] GetSupplierOrderDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public SupplierOrderDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public SupplierOrderDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new SupplierOrderDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(SupplierOrderDetails item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.SupplierOrderId,
                item.PlantId,
                item.Price,
                item.RawMaterialId,
                item.Quantity
            };
        }

        public SupplierOrderDetails[] UpdateSupplierOrderDetails(SupplierOrderDetails[] SupplierOrderDetails)
        {
            if (SupplierOrderDetails.Any())
            {
                base.Update(SupplierOrderDetails);
            }

            return SupplierOrderDetails;
        }

        public SupplierOrderDetails[] DeleteSupplierOrderDetails(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }

            return null;
        }

        public void DeleteSupplierOrderDetailsBySupplierOrderId(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByMasterId(ids, "SupplierOrderId");
            }
        }
    }
}
