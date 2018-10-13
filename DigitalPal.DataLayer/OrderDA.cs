using Dapper;
using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class OrderDA : DataAccessBase<Order>, IOrderDA
    {

        public OrderDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Order;
        }

        public async Task AddOrderAsync(Order[] Orders)
        {
            await base.AddAsync(Orders);
        }

        public Order[] AddOrder(Order[] Orders)
        {
            return base.Add(Orders);
        }
        public Dictionary<string, string> GetMaxNumber()
        {
            using (IDbConnection dbConnection = _sqlConnection)
            {
                var query = string.Format(@"SELECT 'OrderNumber' AS [Key], [OrderNumber] AS [Value] FROM" +
                                           " (SELECT TOP 1 [OrderNumber] FROM {0} ORDER BY CreatedOn DESC) a" +
                                           " UNION" +
                                           " SELECT 'DispatchNumber' AS [Key], [DispatchNumber] AS [Value] FROM" +
                                            " (SELECT TOP 1 [DispatchNumber] FROM {1} ORDER BY CreatedOn DESC) b" +
                                            " UNION" +
                                            " SELECT 'InvoiceNumber' AS [Key],[InvoiceNumber] AS [Value] FROM" +
                                           "  (SELECT TOP 1 [InvoiceNumber] FROM {2} ORDER BY CreatedOn DESC) c" , GetTableName(), TableNameConstants.dp_Dispatch, TableNameConstants.dp_Invoice);
                return dbConnection.Query<KeyValuePair<string, string>>(query).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public Order GetOrder(string id)
        {
            List<Order> _order = new List<Order>();
            var sql = String.Format("select ord.[Id], ord.[OrderNumber], ord.[CustomerPONumber], ord.[CustomerId], cust.[Name] as [CustomerName], ord.[OrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[ProductId] as Products_ProductId, orddeatils.[Quantity] as Products_Quantity ,prod.[Name] as Products_ProductName from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.OrderId" +
                                    " left join {2} Prod on Prod.Id = orddeatils.ProductId" +
                                    " left join {3} cust on cust.Id = ord.CustomerId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Prod.IsActive = 1 and cust.IsActive = 1 and ord.Id = @id",
                                    GetTableName(), TableNameConstants.dp_OrderDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer);

            var dynamicOrder = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Order), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OrderDetails), new List<string> { "ProductId" });
            _order = (Slapper.AutoMapper.MapDynamic<Order>(dynamicOrder) as IEnumerable<Order>).ToList();
            return _order.FirstOrDefault();
        }

        public Order GetOrderInformation(string id)
        {
            List<Order> _order = new List<Order>();
            var sql = String.Format("select ord.[Id], ord.[OrderNumber], ord.[CustomerPONumber], ord.[CustomerId], cust.[Name] as [CustomerName], ord.[OrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[ProductId] as Products_ProductId, orddeatils.[Quantity] as Products_Quantity ,prod.[Name] as Products_ProductName from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.OrderId"+
                                    " left join {2} Prod on Prod.Id = orddeatils.ProductId"+
                                    " left join {3} cust on cust.Id = ord.CustomerId"+
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Prod.IsActive = 1 and cust.IsActive = 1 and ord.Id = @id",
                                    GetTableName(), TableNameConstants.dp_OrderDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer);

            var dynamicOrder = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Order), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OrderDetails), new List<string> { "ProductId" });
            _order = (Slapper.AutoMapper.MapDynamic<Order>(dynamicOrder) as IEnumerable<Order>).ToList();
            return _order.FirstOrDefault();
        }

        public Dictionary<string, Order> GetOrder(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Order[] GetOrder(IEnumerable<Guid?> ids)
        {
            List<Order> _order = new List<Order>();
            var sql = String.Format("select ord.[Id], ord.[OrderNumber], ord.[CustomerPONumber], ord.[CustomerId], cust.[Name] as [CustomerName], ord.[OrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[ProductId] as Products_ProductId, orddeatils.[Quantity] as Products_Quantity ,prod.[Name] as Products_ProductName from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.OrderId" +
                                    " left join {2} Prod on Prod.Id = orddeatils.ProductId" +
                                    " left join {3} cust on cust.Id = ord.CustomerId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Prod.IsActive = 1 and cust.IsActive = 1 and ord.Id In @id",
                                    GetTableName(), TableNameConstants.dp_OrderDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer);

            var dynamicOrder = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Order), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OrderDetails), new List<string> { "ProductId" });
            _order = (Slapper.AutoMapper.MapDynamic<Order>(dynamicOrder) as IEnumerable<Order>).ToList();
            return _order.ToArray();
        }

        public Order[] GetAll()
        {
            List<Order> _order = new List<Order>();
            var sql = String.Format("select ord.[Id], ord.[OrderNumber], ord.[CustomerPONumber], ord.[CustomerId], cust.[Name] as [CustomerName], ord.[OrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[ProductId] as Products_ProductId, orddeatils.[Quantity] as Products_Quantity ,prod.[Name] as Products_ProductName from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.OrderId" +
                                    " left join {2} Prod on Prod.Id = orddeatils.ProductId" +
                                    " left join {3} cust on cust.Id = ord.CustomerId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Prod.IsActive = 1 and cust.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_OrderDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer);

            var dynamicOrder = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Order), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OrderDetails), new List<string> { "ProductId" });
            _order = (Slapper.AutoMapper.MapDynamic<Order>(dynamicOrder) as IEnumerable<Order>).ToList();
            return _order.ToArray();
        }

        public Order[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<Order> _order = new List<Order>();
            var sql = String.Format("select ord.[Id], ord.[OrderNumber], ord.[CustomerPONumber], ord.[CustomerId], cust.[Name] as [CustomerName], ord.[OrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[ProductId] as Products_ProductId, orddeatils.[Quantity] as Products_Quantity ,prod.[Name] as Products_ProductName from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.OrderId" +
                                    " left join {2} Prod on Prod.Id = orddeatils.ProductId" +
                                    " left join {3} cust on cust.Id = ord.CustomerId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Prod.IsActive = 1 and cust.IsActive = 1 and ord.Id In @id",
                                    GetTableName(), TableNameConstants.dp_OrderDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer);

            var dynamicOrder = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Order), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(OrderDetails), new List<string> { "ProductId" });
            _order = (Slapper.AutoMapper.MapDynamic<Order>(dynamicOrder) as IEnumerable<Order>).ToList();
            return _order.ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Order()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Order item)
        {
            return new
            {
                item.CustomerId,
                item.CustomerPONumber,
                item.OrderDate,
                item.OrderNumber,
                item.OrderStatus,
                item.PlantId,
                item.TenantId,
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy,
                item.Price,
                item.Remark
            };
        }

        public Order[] UpdateOrder(Order[] Orders)
        {
            if (Orders.Any())
            {
                base.Update(Orders);
            }

            return Orders;
        }

        public Order DeleteOrder(string id)
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
