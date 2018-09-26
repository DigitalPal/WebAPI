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
    public class CustomerDA : DataAccessBase<Customer>, ICustomerDA
    {

        public CustomerDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Customer;
        }

        public async Task AddCustomerAsync(Customer[] Customers)
        {
            await base.AddAsync(Customers);
        }

        public Customer[] AddCustomers(Customer[] Customers)
        {
            return base.Add(Customers);
        }

        public Customer GetCustomer(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Customer> GetCustomers(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Customer[] GetCustomers(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Customer[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Customer[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new Customer()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Customer item)
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
                item.CustomerNumber,
                item.Description,
                item.GSTNumber,
                item.Type,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public Customer[] UpdateCustomers(Customer[] Customers)
        {
            if (Customers.Any())
            {
                base.Update(Customers);
            }

            return Customers;
        }

        public Customer[] DeleteCustomers(string id)
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
