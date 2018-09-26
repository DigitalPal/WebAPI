using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class CustomerRepository : ICustomerRepository
    {
        private ICustomerDA _CustomerDA;

        public CustomerRepository(ICustomerDA CustomerDA)
        {
            _CustomerDA = CustomerDA;
        }

        public async Task AddAsync(Customer[] Customers)
        {
            await _CustomerDA.AddCustomerAsync(Customers);
        }
        public Customer[] Add(Customer[] Customers)
        {
            return _CustomerDA.AddCustomers(Customers);
        }

        public Customer Get(string id)
        {
            return _CustomerDA.GetCustomer(id);
        }

        public Dictionary<string, Customer> Get(string[] ids)
        {
            return _CustomerDA.GetCustomers(ids);
        }

        public Customer[] Get(IEnumerable<Guid?> ids)
        {
            return _CustomerDA.GetCustomers(ids);
        }

        public Customer[] GetAll()
        {
            return _CustomerDA.GetAll();
        }


        public Customer[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _CustomerDA.GetByIds(Ids);
        }

        public Customer[] Update(Customer[] Customers)
        {
            return _CustomerDA.UpdateCustomers(Customers);
        }

        public Customer[] Delete(string id)
        {
            return _CustomerDA.DeleteCustomers(id);
        }
    }
}
