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
    public class RawMaterialConsumptionDA : DataAccessBase<RawMaterialConsumption>, IRawMaterialConsumptionDA
    {

        public RawMaterialConsumptionDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_RawMaterialConsumption;
        }

        public async Task AddRawMaterialConsumptionAsync(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            await base.AddAsync(RawMaterialConsumptions);
        }

        public RawMaterialConsumption[] AddRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            return base.Add(RawMaterialConsumptions);
        }

        public RawMaterialConsumption GetRawMaterialConsumption(string id)
        {
            List<RawMaterialConsumption> _RawMaterialInward = new List<RawMaterialConsumption>();
            var sql = String.Format("SELECT RMC.[Id], RMC.[ConsumptionDate], RMC.[RawMaterialId], RMD.[Title] AS [RawMaterial], RMC.[Quantity], RMC.[NoOfMouldsCasted], RMC.[Remark], RMC.[CreatedOn], RMC.[CreatedBy], RMC.[ModifiedOn], RMC.[ModifiedBy], RMC.[IsActive], RMC.[TenantId], RMC.[PlantId] FROM {0} RMC" +
                                    " LEFT JOIN {1} RMD ON RMC.RawMaterialId = RMD.Id"+
                                    " WHERE RMC.IsActive = 1 AND RMD.IsActive = 1 AND RMC.Id = @Id",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails);

            var dynamicInvoice = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialConsumption), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialConsumption>(dynamicInvoice) as IEnumerable<RawMaterialConsumption>).ToList();

            return _RawMaterialInward.FirstOrDefault();
           
        }

        public Dictionary<string, RawMaterialConsumption> GetRawMaterialConsumptions(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public RawMaterialConsumption[] GetRawMaterialConsumptions(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public RawMaterialConsumption[] GetAll()
        {
            List<RawMaterialConsumption> _RawMaterialInward = new List<RawMaterialConsumption>();
            var sql = String.Format("SELECT RMC.[Id], RMC.[ConsumptionDate], RMC.[RawMaterialId], RMD.[Title] AS [RawMaterial], RMC.[Quantity], RMC.[NoOfMouldsCasted], RMC.[Remark], RMC.[CreatedOn], RMC.[CreatedBy], RMC.[ModifiedOn], RMC.[ModifiedBy], RMC.[IsActive], RMC.[TenantId], RMC.[PlantId] FROM {0} RMC" +
                                    " LEFT JOIN {1} RMD ON RMC.RawMaterialId = RMD.Id" +
                                    " WHERE RMC.IsActive = 1 AND RMD.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails);

            var dynamicInvoice = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialConsumption), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialConsumption>(dynamicInvoice) as IEnumerable<RawMaterialConsumption>).ToList();

            return _RawMaterialInward.ToArray();
        }

        public RawMaterialConsumption[] Search(RawMaterialConsumption RawMaterialConsumption)
        {
            List<RawMaterialConsumption> _RawMaterialInward = new List<RawMaterialConsumption>();
            var sql = String.Format("SELECT ROW_NUMBER() Over (Order by RMD.Id) As [SrNum], RMC.[ConsumptionDate], RMD.[Title] AS [RawMaterial], RMC.[Quantity] FROM {0} RMC" +
                                    " LEFT JOIN {1} RMD ON RMC.RawMaterialId = RMD.Id" +
                                    " WHERE RMC.IsActive = 1 AND RMD.IsActive = 1 ",
                                    GetTableName(), TableNameConstants.dp_RawMaterialDetails);

            #region Filters
            
            if (!string.IsNullOrEmpty(RawMaterialConsumption.RawMaterial))
            {
                sql += " AND RMD.[Title] like '%" + RawMaterialConsumption.RawMaterial + "%'";
            }

            if (RawMaterialConsumption.StartDate != null)
            {
                sql += " AND RMC.[ConsumptionDate] >= '" + RawMaterialConsumption.StartDate + "'";
            }

            if (RawMaterialConsumption.EndDate != null)
            {
                sql += " AND RMC.[ConsumptionDate] <= '" + RawMaterialConsumption.EndDate + "'";
            }

            #endregion Filters

            var dynamicInvoice = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(RawMaterialConsumption), new List<string> { "Id" });

            _RawMaterialInward = (Slapper.AutoMapper.MapDynamic<RawMaterialConsumption>(dynamicInvoice) as IEnumerable<RawMaterialConsumption>).ToList();

            return _RawMaterialInward.ToArray();
        }

        public RawMaterialConsumption[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new RawMaterialConsumption()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(RawMaterialConsumption item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.NoOfMouldsCasted,
                item.RawMaterialId,
                item.Remark,
                item.Quantity,
                item.ConsumptionDate,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public RawMaterialConsumption[] UpdateRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            if (RawMaterialConsumptions.Any())
            {
                base.Update(RawMaterialConsumptions);
            }

            return RawMaterialConsumptions;
        }

        public RawMaterialConsumption[] DeleteRawMaterialConsumptions(string id)
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
