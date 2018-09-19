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
    public class RawMaterialDetailsDA : DataAccessBase<RawMaterialDetails>, IRawMaterialDetailsDA
    {

        public RawMaterialDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_RawMaterialDetails;
        }

        public async Task AddRawMaterialDetailsAsync(RawMaterialDetails[] RawMaterialDetailss)
        {
            await base.AddAsync(RawMaterialDetailss);
        }

        public RawMaterialDetails[] AddRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss)
        {
            return base.Add(RawMaterialDetailss);
        }

        public RawMaterialDetails GetRawMaterialDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, RawMaterialDetails> GetRawMaterialDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public RawMaterialDetails[] GetRawMaterialDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public RawMaterialDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public RawMaterialDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new RawMaterialDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(RawMaterialDetails item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.MeasureType,
                item.Title
            };
        }

        public RawMaterialDetails[] UpdateRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss)
        {
            if (RawMaterialDetailss.Any())
            {
                base.Update(RawMaterialDetailss);
            }

            return RawMaterialDetailss;
        }

        public RawMaterialDetails[] DeleteRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss)
        {
            if (RawMaterialDetailss.Any())
            {
                base.DeleteByDbId(RawMaterialDetailss.Select(x => x.Id.ToString()).ToArray());
            }

            return RawMaterialDetailss;
        }
    }
}
