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

        public RawMaterialInward GetRawMaterialInward(string id)
        {
            return FindById(Guid.Parse(id));
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
            return base.FindAll().ToArray();
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
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.InwardDate,
                item.Quantity,
                item.RawMaterialId,
                item.Remarks,
                item.SupplierId,
                item.UnloadingDetails,
                item.VechicalNumber,
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
