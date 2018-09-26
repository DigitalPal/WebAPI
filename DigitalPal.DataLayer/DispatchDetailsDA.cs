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
    public class DispatchDetailsDA : DataAccessBase<DispatchDetails>, IDispatchDetailsDA
    {

        public DispatchDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_DispatchDetails;
        }

        public async Task AddDispatchDetailsAsync(DispatchDetails[] DispatchDetailss)
        {
            await base.AddAsync(DispatchDetailss);
        }

        public DispatchDetails[] AddDispatchDetails(DispatchDetails[] DispatchDetailss)
        {
            return base.Add(DispatchDetailss);
        }

        public DispatchDetails GetDispatchDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, DispatchDetails> GetDispatchDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public DispatchDetails[] GetDispatchDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public DispatchDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public DispatchDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new DispatchDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(DispatchDetails item)
        {
            return new
            {
                item.Id,
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.ChallanNumber,
                item.CustomerId,
                item.DispatchDate,
                item.Loading,
                item.Unloading,
                item.TransportName,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public DispatchDetails[] UpdateDispatchDetails(DispatchDetails[] DispatchDetailss)
        {
            if (DispatchDetailss.Any())
            {
                base.Update(DispatchDetailss);
            }

            return DispatchDetailss;
        }

        public DispatchDetails[] DeleteDispatchDetails(string id)
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
