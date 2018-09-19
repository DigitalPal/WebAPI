using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface ITenantDA
    {
        Task AddTenantAsync(Tenant[] Tenants);
        Tenant[] AddTenants(Tenant[] Tenants);

        Tenant GetTenant(string id);

        Dictionary<string, Tenant> GetTenants(string[] ids);

        Tenant[] GetTenants(IEnumerable<Guid?> ids);

        Tenant[] GetAll();

        Tenant[] GetByIds(IEnumerable<Guid> Ids);

        Tenant[] UpdateTenants(Tenant[] Tenants);

        Tenant[] DeleteTenants(Tenant[] Tenants);
    }
}
