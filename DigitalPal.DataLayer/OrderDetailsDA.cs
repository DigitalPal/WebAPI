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
    public class OrderDetailsDA : DataAccessBase<OrderDetails>, IOrderDetailsDA
    {

        public OrderDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_OrderDetails;
        }

        public async Task AddOrderDetailsAsync(OrderDetails[] OrderDetails)
        {
            await base.AddAsync(OrderDetails);
        }

        public OrderDetails[] AddOrderDetails(OrderDetails[] OrderDetails)
        {
            return base.Add(OrderDetails);
        }

        public OrderDetails GetOrderDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, OrderDetails> GetOrderDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public OrderDetails[] GetOrderDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public OrderDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public OrderDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new OrderDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(OrderDetails item)
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
                item.OrderId,
                item.PlantId,
                item.Price,
                item.ProductId,
                item.Quantity
            };
        }

        public OrderDetails[] UpdateOrderDetails(OrderDetails[] OrderDetails)
        {
            if (OrderDetails.Any())
            {
                base.Update(OrderDetails);
            }

            return OrderDetails;
        }

        public OrderDetails[] DeleteOrderDetails(string id)
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
