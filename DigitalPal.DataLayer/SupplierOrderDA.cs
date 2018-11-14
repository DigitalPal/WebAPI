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
    public class SupplierOrderDA : DataAccessBase<SupplierOrder>, ISupplierOrderDA
    {

        public SupplierOrderDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_SupplierOrder;
        }

        public async Task AddSupplierOrderAsync(SupplierOrder[] SupplierOrders)
        {
            await base.AddAsync(SupplierOrders);
        }

        public SupplierOrder[] AddSupplierOrder(SupplierOrder[] SupplierOrders)
        {
            return base.Add(SupplierOrders);
        }
        public Dictionary<string, string> GetMaxNumber()
        {
            using (IDbConnection dbConnection = _sqlConnection)
            {
                var query = string.Format(@"SELECT 'SupplierOrderNumber' AS [Key], [SupplierOrderNumber] AS [Value] FROM" +
                                           " (SELECT TOP 1 [SupplierOrderNumber] FROM {0} ORDER BY CreatedOn DESC) a" +
                                           " UNION" +
                                           " SELECT 'DispatchNumber' AS [Key], [DispatchNumber] AS [Value] FROM" +
                                            " (SELECT TOP 1 [DispatchNumber] FROM {1} ORDER BY CreatedOn DESC) b" +
                                            " UNION" +
                                            " SELECT 'InvoiceNumber' AS [Key],[InvoiceNumber] AS [Value] FROM" +
                                           "  (SELECT TOP 1 [InvoiceNumber] FROM {2} ORDER BY CreatedOn DESC) c", GetTableName(), TableNameConstants.dp_Dispatch, TableNameConstants.dp_Invoice);
                return dbConnection.Query<KeyValuePair<string, string>>(query).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public SupplierOrder GetSupplierOrder(string id)
        {
            List<SupplierOrder> _SupplierOrder = new List<SupplierOrder>();
            var sql = String.Format("select ord.[Id], ord.[SupplierOrderNumber], ord.[SupplierPONumber], ord.[SupplierId], Sup.[SupplierName] as [SupplierName], ord.[SupplierOrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[RawMaterialId] as RawMaterial_RawMaterialId, Raw.[Title] as RawMaterial_RawMaterialName, Raw.[MeasureType] as RawMaterial_MeasureType  from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.SupplierOrderId" +
                                    " left join {2} Raw on Raw.Id = orddeatils.RawMaterialId" +
                                    " left join {3} Sup on Sup.Id = ord.SupplierId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Raw.IsActive = 1 and Sup.IsActive = 1 and ord.Id = @id",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicSupplierOrder = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrder), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderDetails), new List<string> { "RawMaterialId" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrder>(dynamicSupplierOrder) as IEnumerable<SupplierOrder>).ToList();
            return _SupplierOrder.FirstOrDefault();
        }

        public SupplierOrder GetSupplierOrderInformation(string id)
        {
            List<SupplierOrder> _SupplierOrder = new List<SupplierOrder>();
            var sql = String.Format("select ord.[Id], ord.[SupplierOrderNumber], ord.[SupplierPONumber], ord.[SupplierId], Sup.[SupplierName] as [SupplierName], ord.[SupplierOrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[RawMaterialId] as RawMaterial_RawMaterialId, Raw.[Title] as RawMaterial_RawMaterialName, Raw.[MeasureType] as RawMaterial_MeasureType, orddeatils.Quantity as RawMaterial_Quantity  from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.SupplierOrderId" +
                                    " left join {2} Raw on Raw.Id = orddeatils.RawMaterialId"+
                                    " left join {3} Sup on Sup.Id = ord.SupplierId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Raw.IsActive = 1 and Sup.IsActive = 1 and ord.Id = @id",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicSupplierOrder = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrder), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderDetails), new List<string> { "RawMaterialId" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrder>(dynamicSupplierOrder) as IEnumerable<SupplierOrder>).ToList();
            return _SupplierOrder.FirstOrDefault();
        }

        public Dictionary<string, SupplierOrder> GetSupplierOrder(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public SupplierOrder[] GetSupplierOrder(IEnumerable<Guid?> ids)
        {
            List<SupplierOrder> _SupplierOrder = new List<SupplierOrder>();
            var sql = String.Format("select ord.[Id], ord.[SupplierOrderNumber], ord.[SupplierPONumber], ord.[SupplierId], Sup.[SupplierName] as [SupplierName], ord.[SupplierOrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[RawMaterialId] as RawMaterial_RawMaterialId, Raw.[Title] as RawMaterial_RawMaterialName, Raw.[MeasureType] as RawMaterial_MeasureType  from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.SupplierOrderId" +
                                    " left join {2} Raw on Raw.Id = orddeatils.RawMaterialId" +
                                    " left join {3} Sup on Sup.Id = ord.SupplierId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Raw.IsActive = 1 and Sup.IsActive = 1 and ord.Id In @id",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicSupplierOrder = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrder), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderDetails), new List<string> { "RawMaterialId" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrder>(dynamicSupplierOrder) as IEnumerable<SupplierOrder>).ToList();
            return _SupplierOrder.ToArray();
        }

        public SupplierOrder[] GetAll()
        {
            List<SupplierOrder> _SupplierOrder = new List<SupplierOrder>();
            var sql = String.Format("select ord.[Id], ord.[SupplierOrderNumber], ord.[SupplierPONumber], ord.[SupplierId], Sup.[SupplierName] as [SupplierName], ord.[SupplierOrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[RawMaterialId] as RawMaterial_RawMaterialId, Raw.[Title] as RawMaterial_RawMaterialName, Raw.[MeasureType] as RawMaterial_MeasureType  from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.SupplierOrderId" +
                                    " left join {2} Raw on Raw.Id = orddeatils.RawMaterialId" +
                                    " left join {3} Sup on Sup.Id = ord.SupplierId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Raw.IsActive = 1 and Sup.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicSupplierOrder = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrder), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderDetails), new List<string> { "RawMaterialId" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrder>(dynamicSupplierOrder) as IEnumerable<SupplierOrder>).ToList();
            return _SupplierOrder.ToArray();
        }

        public SupplierOrderReport[] Search(SupplierOrder SupplierOrder)
        {
            List<SupplierOrderReport> _SupplierOrder = new List<SupplierOrderReport>();
            var sql = String.Format("SELECT ROW_NUMBER() Over (Order by ord.Id) As [SrNum], ord.[SupplierOrderNumber], Sup.[SupplierName], ord.[SupplierOrderDate], orddeatils.[Quantity], Raw.[Title] as RawMaterialName FROM {0} ord " +
                                    " LEFT JOIN {1} orddeatils ON ord.Id = orddeatils.SupplierOrderId" +
                                    " LEFT JOIN {2} Raw ON Raw.Id = orddeatils.RawMaterialId" +
                                    " LEFT JOIN {3} Sup ON Sup.Id = ord.SupplierId" +
                                    " WHERE ord.IsActive = 1 AND orddeatils.IsActive = 1 AND Raw.IsActive = 1 AND Sup.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            #region Filters
            if (SupplierOrder != null)
            {
                if (!string.IsNullOrEmpty(SupplierOrder.SupplierName))
                {
                    sql += " AND Sup.[SupplierName] like '%" + SupplierOrder.SupplierName + "%'";
                }

                if (!string.IsNullOrEmpty(SupplierOrder.SupplierOrderNumber))
                {
                    sql += " AND ord.[SupplierOrderNumber] = '" + SupplierOrder.SupplierOrderNumber + "'";
                }

                if (SupplierOrder.StartDate != null)
                {
                    sql += " AND ord.[SupplierOrderDate] >= '" + SupplierOrder.StartDate + "'";
                }

                if (SupplierOrder.EndDate != null)
                {
                    sql += " AND ord.[SupplierOrderDate] <= '" + SupplierOrder.EndDate + "'";
                }
            }
            #endregion Filters

            var dynamicSupplierOrder = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderReport), new List<string> { "SrNum" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrderReport>(dynamicSupplierOrder) as IEnumerable<SupplierOrderReport>).ToList();
            return _SupplierOrder.ToArray();
        }
        public SupplierOrder[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<SupplierOrder> _SupplierOrder = new List<SupplierOrder>();
            var sql = String.Format("select ord.[Id], ord.[SupplierOrderNumber], ord.[SupplierPONumber], ord.[SupplierId], Sup.[SupplierName] as [SupplierName], ord.[SupplierOrderDate], ord.[Price], ord.[Remark], ord.[OrderStatus], ord.[CreatedOn], ord.[CreatedBy], ord.[ModifiedOn], ord.[ModifiedBy], ord.[IsActive], ord.[TenantId], ord.[PlantId], orddeatils.[RawMaterialId] as RawMaterial_RawMaterialId, Raw.[Title] as RawMaterial_RawMaterialName, Raw.[MeasureType] as RawMaterial_MeasureType  from {0} ord " +
                                    " left join {1} orddeatils on ord.Id = orddeatils.SupplierOrderId" +
                                    " left join {2} Raw on Raw.Id = orddeatils.RawMaterialId" +
                                    " left join {3} Sup on Sup.Id = ord.SupplierId" +
                                    " Where ord.IsActive = 1 and orddeatils.IsActive = 1 and Raw.IsActive = 1 and Sup.IsActive = 1 and ord.Id In @id",
                                    GetTableName(), TableNameConstants.dp_SupplierOrderDetails, TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicSupplierOrder = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrder), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierOrderDetails), new List<string> { "RawMaterialId" });
            _SupplierOrder = (Slapper.AutoMapper.MapDynamic<SupplierOrder>(dynamicSupplierOrder) as IEnumerable<SupplierOrder>).ToList();
            return _SupplierOrder.ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new SupplierOrder()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(SupplierOrder item)
        {
            return new
            {
                item.SupplierId,
                item.SupplierPONumber,
                item.SupplierOrderDate,
                item.SupplierOrderNumber,
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

        public SupplierOrder[] UpdateSupplierOrder(SupplierOrder[] SupplierOrders)
        {
            if (SupplierOrders.Any())
            {
                base.Update(SupplierOrders);
            }

            return SupplierOrders;
        }

        public SupplierOrder DeleteSupplierOrder(string id)
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
