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
    public class TenantDA : DataAccessBase<Tenant>, ITenantDA
    {

        public TenantDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Tenant;
        }

        public async Task AddTenantAsync(Tenant[] Tenants)
        {
            await base.AddAsync(Tenants);
        }

        public Tenant[] AddTenants(Tenant[] Tenants)
        {
            return base.Add(Tenants);
        }

        public Tenant GetTenant(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Tenant> GetTenants(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return  result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Tenant[] GetTenants(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Tenant[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Tenant[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new Tenant()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Tenant item)
        {
            return new
            {
                item.Id,
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.Address,
                item.ContactNumber,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy
            };
        }

        public Tenant[] UpdateTenants(Tenant[] Tenants)
        {
            if (Tenants.Any())
            {
                base.Update(Tenants);
            }

            return Tenants;
        }

        public Tenant[] DeleteTenants(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }

            return null;
        }
    }
}
