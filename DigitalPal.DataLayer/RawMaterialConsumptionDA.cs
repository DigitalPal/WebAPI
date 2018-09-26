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
            return FindById(Guid.Parse(id));
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
            return base.FindAll().ToArray();
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
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.NoOfMouldsCasted,
                item.RawMaterialId,
                item.Remark,
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
