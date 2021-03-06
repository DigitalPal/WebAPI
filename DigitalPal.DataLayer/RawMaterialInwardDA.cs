﻿using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class RawMaterialInwardDA : DataAccessBase<RawMaterialInward>, IRawMaterialInwardDA
    {

        public RawMaterialInwardDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_RawMaterialInward;
        }

        public async Task AddRawMaterialInwardAsync(RawMaterialInward[] RawMaterialInwards)
        {
            await base.AddAsync(RawMaterialInwards);
        }

        public RawMaterialInward[] AddRawMaterialInwards(RawMaterialInward[] RawMaterialInwards)
        {
            return base.Add(RawMaterialInwards);
        }

        public RawMaterialInward[] Search(RawMaterialInward RawMaterialInward)
        {
            List<RawMaterialInward> _RawMaterialInward = new List<RawMaterialInward>();
            var sql = String.Format("SELECT ROW_NUMBER() Over (Order by RMI.Id) As [SrNum], RMI.Id As [Id], RMI.[InwardDate], RMD.Title AS RawMaterial, SUP.SupplierName AS SupplierName, RMI.[VechicalNumber], RMI.[ChallanNumber], RMI.[Quantity], RMI.[UnloadingDetails], RMI.[Remark], RMI.[CreatedOn], RMI.[CreatedBy], RMI.[ModifiedOn], RMI.[ModifiedBy], RMI.[IsActive], RMI.[TenantId], RMI.[PlantId] FROM {0}" +
                                    " RMI LEFT JOIN {1} RMD ON RMD.Id = RMI.[RawMaterialId]" +
                                    " LEFT JOIN {2} SUP ON SUP.Id = RMI.SupplierId" +
                                    " WHERE RMI.IsActive = 1 AND RMD.IsActive = 1 AND SUP.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            #region Filters

            if (!string.IsNullOrEmpty(RawMaterialInward.SupplierName))
            {
                sql += " AND SUP.SupplierName like '%" + RawMaterialInward.SupplierName + "%'";
            }

            if (!string.IsNullOrEmpty(RawMaterialInward.ChallanNumber))
            {
                sql += " AND RMI.[ChallanNumber] = '" + RawMaterialInward.ChallanNumber + "'";
            }

            if (!string.IsNullOrEmpty(RawMaterialInward.RawMaterial))
            {
                sql += " AND RMD.Title like '%" + RawMaterialInward.RawMaterial + "%'";
            }

            if (RawMaterialInward.StartDate != null)
            {
                sql += " AND RMI.[InwardDate] >= '" + RawMaterialInward.StartDate + "'";
            }

            if (RawMaterialInward.EndDate != null)
            {
                sql += " AND RMI.[InwardDate] <= '" + RawMaterialInward.EndDate + "'";
            }

            #endregion Filters

            var dynamicInvoice = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialInward), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialInward>(dynamicInvoice) as IEnumerable<RawMaterialInward>).ToList();

            return _RawMaterialInward.ToArray();
        }

        public RawMaterialInward GetRawMaterialInward(string id)
        {
            List<RawMaterialInward> _RawMaterialInward = new List<RawMaterialInward>();
            var sql = String.Format("SELECT RMI.[Id], RMI.[InwardDate], RMI.[RawMaterialId], RMD.Title AS RawMaterial, RMI.[SupplierId], SUP.SupplierName AS SupplierName, RMI.[VechicalNumber], RMI.[ChallanNumber], RMI.[Quantity], RMI.[UnloadingDetails], RMI.[Remark], RMI.[CreatedOn], RMI.[CreatedBy], RMI.[ModifiedOn], RMI.[ModifiedBy], RMI.[IsActive], RMI.[TenantId], RMI.[PlantId] FROM {0}" +
                                    " RMI LEFT JOIN {1} RMD ON RMD.Id = RMI.[RawMaterialId]" +
                                    " LEFT JOIN {2} SUP ON SUP.Id = RMI.SupplierId" +
                                    " WHERE RMI.IsActive = 1 AND RMD.IsActive = 1 AND SUP.IsActive = 1 AND RMI.Id = @Id",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicInvoice = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialInward), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialInward>(dynamicInvoice) as IEnumerable<RawMaterialInward>).ToList();

            return _RawMaterialInward.FirstOrDefault();
        }

        public Dictionary<string, RawMaterialInward> GetRawMaterialInwards(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public RawMaterialInward[] GetRawMaterialInwards(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public RawMaterialInward[] GetAll()
        {
            List<RawMaterialInward> _RawMaterialInward = new List<RawMaterialInward>();
            var sql = String.Format("SELECT RMI.[Id], RMI.[InwardDate], RMI.[RawMaterialId], RMD.Title AS RawMaterial, RMI.[SupplierId], SUP.SupplierName AS SupplierName, RMI.[VechicalNumber], RMI.[ChallanNumber], RMI.[Quantity], RMI.[UnloadingDetails], RMI.[Remark], RMI.[CreatedOn], RMI.[CreatedBy], RMI.[ModifiedOn], RMI.[ModifiedBy], RMI.[IsActive], RMI.[TenantId], RMI.[PlantId] FROM {0}" +
                                    " RMI LEFT JOIN {1} RMD ON RMD.Id = RMI.[RawMaterialId]"+
                                    " LEFT JOIN {2} SUP ON SUP.Id = RMI.SupplierId" +
                                    " WHERE RMI.IsActive = 1 AND RMD.IsActive = 1 AND SUP.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails, TableNameConstants.dp_Supplier);

            var dynamicInvoice = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialInward), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialInward>(dynamicInvoice) as IEnumerable<RawMaterialInward>).ToList();

            return _RawMaterialInward.ToArray();
        }

        public RawMaterialInward[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new RawMaterialInward()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(RawMaterialInward item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.InwardDate,
                item.Quantity,
                item.RawMaterialId,
                item.Remark,
                item.SupplierId,
                item.UnloadingDetails,
                item.VechicalNumber,
                item.ChallanNumber,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public RawMaterialInward[] UpdateRawMaterialInwards(RawMaterialInward[] RawMaterialInwards)
        {
            if (RawMaterialInwards.Any())
            {
                base.Update(RawMaterialInwards);
            }

            return RawMaterialInwards;
        }

        public RawMaterialInward[] DeleteRawMaterialInwards(string id)
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
