using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface ITenantRepository
    {
        Task AddAsync(Tenant[] Tenants);
        Tenant[] Add(Tenant[] Tenants);

        Tenant Get(string id);

        Dictionary<string, Tenant> Get(string[] ids);

        Tenant[] Get(IEnumerable<Guid?> ids);
        Tenant[] GetAll();

        Tenant[] GetByIds(IEnumerable<Guid> Ids);

        Tenant[] Update(Tenant[] Tenants);

        Tenant[] Delete(string id);
    }
}
