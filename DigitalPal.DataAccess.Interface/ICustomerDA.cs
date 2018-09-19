using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface ICustomerDA
    {
        Task AddCustomerAsync(Customer[] Customers);
        Customer[] AddCustomers(Customer[] Customers);

        Customer GetCustomer(string id);

        Dictionary<string, Customer> GetCustomers(string[] ids);

        Customer[] GetCustomers(IEnumerable<Guid?> ids);

        Customer[] GetAll();

        Customer[] GetByIds(IEnumerable<Guid> Ids);

        Customer[] UpdateCustomers(Customer[] Customers);

        Customer[] DeleteCustomers(Customer[] Customers);
    }
}
