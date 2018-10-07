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
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Dispatch> GetDispatch(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Dispatch[] GetDispatch(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Dispatch[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Dispatch[] GetByIds(IEnumerable<Guid> Ids)
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
                item.DispatchDate,
                item.Unloading,
                item.TransportName,
                item.DispatchStatus,
                item.OrderId,
                item.Quantity,
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

        public Dispatch[] DeleteDispatch(string id)
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
