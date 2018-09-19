using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer[] Customers);
        Customer[] Add(Customer[] Customers);

        Customer Get(string id);

        Dictionary<string, Customer> Get(string[] ids);

        Customer[] Get(IEnumerable<Guid?> ids);
        Customer[] GetAll();

        Customer[] GetByIds(IEnumerable<Guid> Ids);

        Customer[] Update(Customer[] Customers);

        Customer[] Delete(Customer[] Customers);
    }
}
