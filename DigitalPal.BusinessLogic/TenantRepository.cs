using Autofac.Extras.DynamicProxy;
using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Common.LogUtils;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    //[Intercept(typeof(CallLogger))]
    public class TenantRepository: ITenantRepository
    {
        private ITenantDA _tenantDA;

        public TenantRepository(ITenantDA tenantDA)
        {
            _tenantDA = tenantDA;
        }

        public async Task AddAsync(Tenant[] tenants)
        {
            await _tenantDA.AddTenantAsync(tenants);
        }
        public Tenant[] Add(Tenant[] tenants)
        {
           return _tenantDA.AddTenants(tenants);
        }

        public Tenant Get(string id)
        {
            return _tenantDA.GetTenant(id);
        }

        public Dictionary<string, Tenant> Get(string[] ids)
        {
            return _tenantDA.GetTenants(ids);
        }

        public Tenant[] Get(IEnumerable<Guid?> ids)
        {
            return _tenantDA.GetTenants(ids);
        }

        public Tenant[] GetAll()
        {
            return _tenantDA.GetAll();
        }


        public Tenant[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _tenantDA.GetByIds(Ids);
        }

        public Tenant[] Update(Tenant[] tenants)
        {
            return _tenantDA.UpdateTenants(tenants);
        }

        public Tenant[] Delete(string id)
        {
            return _tenantDA.DeleteTenants(id);
        }
    }
}
