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
    public class DispatchDA : DataAccessBase<Dispatch>, IDispatchDA
    {

        public DispatchDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Dispatch;
        }

        public async Task AddDispatchAsync(Dispatch[] Dispatchs)
        {
            await base.AddAsync(Dispatchs);
        }

        public Dispatch[] AddDispatch(Dispatch[] Dispatchs)
        {
            return base.Add(Dispatchs);
        }

        public Dispatch GetDispatch(string id)
        {
            List<Dispatch> _dispatch = new List<Dispatch>();
            var sql = String.Format("select dispatch.[Id], dispatch.[DispatchNumber], dispatch.[DispatchDate], dispatch.[OrderId], dispatch.[ChallanNumber], dispatch.[Size], dispatch.[Quantity], dispatch.[TransportName], dispatch.[Loading], dispatch.[Unloading], dispatch.[Rate], dispatch.[Remark], dispatch.[DispatchStatus], dispatch.[CreatedOn], dispatch.[CreatedBy], dispatch.[ModifiedOn], dispatch.[ModifiedBy], dispatch.[IsActive], dispatch.[TenantId], dispatch.[PlantId], dispatchdeatils.[ProductId] AS DispatchDetails_ProductId, Prod.[Size] AS DispatchDetails_Size, Prod.[Height] AS DispatchDetails_Height , Prod.[Width] AS DispatchDetails_Width , Prod.[Length] AS DispatchDetails_Length, dispatchdeatils.[Quantity] AS DispatchDetails_Quantity, dispatchdeatils.[Rate] AS DispatchDetails_Rate, prod.[Name] AS DispatchDetails_ProductName" +
                                    " from {0} dispatch" +
                                    " left join {1} dispatchdeatils on dispatch.Id = dispatchdeatils.DispatchId" +
                                    " left join {2} Prod on Prod.Id = dispatchdeatils.ProductId" +
                                    " Where dispatch.IsActive = 1 and dispatchdeatils.IsActive = 1 and Prod.IsActive = 1 and dispatch.Id = @id",
                                    GetTableName(), TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product);

            var dynamicOrder = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Dispatch), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchDetails), new List<string> { "ProductId" });
            _dispatch = (Slapper.AutoMapper.MapDynamic<Dispatch>(dynamicOrder) as IEnumerable<Dispatch>).ToList();
            return _dispatch.FirstOrDefault();
        }

        public Dictionary<string, Dispatch> GetDispatch(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Dispatch[] GetDispatch(IEnumerable<Guid?> ids)
        {
            List<Dispatch> _dispatch = new List<Dispatch>();
            var sql = String.Format("select dispatch.[Id], dispatch.[DispatchNumber], dispatch.[DispatchDate], dispatch.[OrderId], dispatch.[ChallanNumber], dispatch.[Size], dispatch.[Quantity], dispatch.[TransportName], dispatch.[Loading], dispatch.[Unloading], dispatch.[Rate], dispatch.[Remark], dispatch.[DispatchStatus], dispatch.[CreatedOn], dispatch.[CreatedBy], dispatch.[ModifiedOn], dispatch.[ModifiedBy], dispatch.[IsActive], dispatch.[TenantId], dispatch.[PlantId], dispatchdeatils.[ProductId] AS DispatchDetails_ProductId, dispatchdeatils.[Quantity] AS DispatchDetails_Quantity, dispatchdeatils.[Rate] AS DispatchDetails_Rate, prod.[Name] AS DispatchDetails_ProductName, Prod.[Size] AS DispatchDetails_Size, Prod.[Height] AS DispatchDetails_Height , Prod.[Width] AS DispatchDetails_Width , Prod.[Length] AS DispatchDetails_Length" +
                                    " from {0} dispatch" +
                                    " left join {1} dispatchdeatils on dispatch.Id = dispatchdeatils.DispatchId" +
                                    " left join {2} Prod on Prod.Id = dispatchdeatils.ProductId" +
                                    " Where dispatch.IsActive = 1 and dispatchdeatils.IsActive = 1 and Prod.IsActive = 1 and dispatch.Id In @id",
                                    GetTableName(), TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product);

            var dynamicOrder = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Dispatch), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchDetails), new List<string> { "ProductId" });
            _dispatch = (Slapper.AutoMapper.MapDynamic<Dispatch>(dynamicOrder) as IEnumerable<Dispatch>).ToList();
            return _dispatch.ToArray();
        }

        public Dispatch[] GetAll()
        {
            List<Dispatch> _dispatch = new List<Dispatch>();
            var sql = String.Format("select dispatch.[Id], Ord.[OrderNumber], dispatch.[DispatchNumber], dispatch.[DispatchDate], dispatch.[OrderId], dispatch.[ChallanNumber], dispatch.[Size], dispatch.[Quantity], dispatch.[TransportName], dispatch.[Loading], dispatch.[Unloading], dispatch.[Rate], dispatch.[Remark], dispatch.[DispatchStatus], dispatch.[CreatedOn], dispatch.[CreatedBy], dispatch.[ModifiedOn], dispatch.[ModifiedBy], dispatch.[IsActive], dispatch.[TenantId], dispatch.[PlantId], dispatchdeatils.[ProductId] AS DispatchDetails_ProductId, dispatchdeatils.[Quantity] AS DispatchDetails_Quantity, dispatchdeatils.[Rate] AS DispatchDetails_Rate, prod.[Name] AS DispatchDetails_ProductName, Prod.[Size] AS DispatchDetails_Size, Prod.[Height] AS DispatchDetails_Height , Prod.[Width] AS DispatchDetails_Width , Prod.[Length] AS DispatchDetails_Length" +
                                    " from {0} dispatch" +
                                    " left join {1} dispatchdeatils on dispatch.Id = dispatchdeatils.DispatchId" +
                                    " left join {2} Prod on Prod.Id = dispatchdeatils.ProductId" +
                                    " left join {3} Ord on Ord.Id = dispatch.OrderId" +
                                    " Where dispatch.IsActive = 1 and dispatchdeatils.IsActive = 1 and Prod.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Order);

            var dynamicDispatch = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Dispatch), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchDetails), new List<string> { "ProductId" });
            _dispatch = (Slapper.AutoMapper.MapDynamic<Dispatch>(dynamicDispatch) as IEnumerable<Dispatch>).ToList();
            return _dispatch.ToArray();
        }

        public DispatchReport[] Search(DispatchReport Dispatch)
        {
            List<DispatchReport> _dispatch = new List<DispatchReport>();
            var sql = String.Format("SELECT ROW_NUMBER() Over (Order by dispatch.Id) As [SrNum], Ord.[OrderNumber], Cust.[Name] AS CustomerName, dispatch.[DispatchDate], prod.[Name] AS ProductName, dispatch.[Quantity], dispatch.[TransportName], dispatch.[Loading], dispatch.[Unloading] " +
                                    " FROM {0} dispatch" +
                                    " LEFT JOIN {1} dispatchdeatils ON dispatch.Id = dispatchdeatils.DispatchId" +
                                    " LEFT JOIN {2} Prod ON Prod.Id = dispatchdeatils.ProductId" +
                                    " LEFT JOIN {3} Ord ON Ord.Id = dispatch.OrderId" +
                                    " LEFT JOIN {4} Cust ON Cust.Id = Ord.CustomerId" +
                                    " WHERE dispatch.IsActive = 1 AND dispatchdeatils.IsActive = 1 AND Prod.IsActive = 1 AND Cust.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Order, TableNameConstants.dp_Customer);

            #region Filters

            if (!string.IsNullOrEmpty(Dispatch.CustomerName))
            {
                sql += " AND Cust.[Name] like '%" + Dispatch.CustomerName + "%'";
            }

            if (!string.IsNullOrEmpty(Dispatch.OrderNumber))
            {
                sql += " AND Ord.[OrderNumber] = '" + Dispatch.OrderNumber + "'";
            }

            if (Dispatch.StartDate != null)
            {
                sql += " AND dispatch.[DispatchDate] >= '" + Dispatch.StartDate + "'";
            }

            if (Dispatch.EndDate != null)
            {
                sql += " AND dispatch.[DispatchDate] <= '" + Dispatch.EndDate + "'";
            }

            #endregion Filters

            var dynamicDispatch = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchReport), new List<string> { "Id" });
            _dispatch = (Slapper.AutoMapper.MapDynamic<DispatchReport>(dynamicDispatch) as IEnumerable<DispatchReport>).ToList();
            return _dispatch.ToArray();
        }

        public Dispatch[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<Dispatch> _dispatch = new List<Dispatch>();
            var sql = String.Format("select dispatch.[Id], dispatch.[DispatchNumber], dispatch.[DispatchDate], dispatch.[OrderId], dispatch.[ChallanNumber], dispatch.[Size], dispatch.[Quantity], dispatch.[TransportName], dispatch.[Loading], dispatch.[Unloading], dispatch.[Rate], dispatch.[Remark], dispatch.[DispatchStatus], dispatch.[CreatedOn], dispatch.[CreatedBy], dispatch.[ModifiedOn], dispatch.[ModifiedBy], dispatch.[IsActive], dispatch.[TenantId], dispatch.[PlantId], dispatchdeatils.[ProductId] AS DispatchDetails_ProductId, dispatchdeatils.[Quantity] AS DispatchDetails_Quantity, dispatchdeatils.[Rate] AS DispatchDetails_Rate, prod.[Name] AS DispatchDetails_ProductName, Prod.[Size] AS DispatchDetails_Size, Prod.[Height] AS DispatchDetails_Height , Prod.[Width] AS DispatchDetails_Width , Prod.[Length] AS DispatchDetails_Length" +
                                    " from {0} dispatch" +
                                    " left join {1} dispatchdeatils on dispatch.Id = dispatchdeatils.DispatchId" +
                                    " left join {2} Prod on Prod.Id = dispatchdeatils.ProductId" +
                                    " Where dispatch.IsActive = 1 and dispatchdeatils.IsActive = 1 and Prod.IsActive = 1 and dispatch.Id In @id",
                                    GetTableName(), TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product);

            var dynamicOrder = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Dispatch), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchDetails), new List<string> { "ProductId" });
            _dispatch = (Slapper.AutoMapper.MapDynamic<Dispatch>(dynamicOrder) as IEnumerable<Dispatch>).ToList();
            return _dispatch.ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Dispatch()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Dispatch item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.ChallanNumber,
                item.DispatchNumber,
                item.DispatchDate,
                item.Loading,
                item.Unloading,
                item.TransportName,
                item.DispatchStatus,
                item.OrderId,
                item.Rate,
                item.Remark,
                item.Size,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public Dispatch[] UpdateDispatch(Dispatch[] Dispatchs)
        {
            if (Dispatchs.Any())
            {
                base.Update(Dispatchs);
            }

            return Dispatchs;
        }

        public void DeleteDispatch(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }
        }
    }
}
