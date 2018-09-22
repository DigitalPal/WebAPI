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
    public class PriceDetailsDA : DataAccessBase<PriceDetails>, IPriceDetailsDA
    {

        public PriceDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_PriceDetails;
        }

        public async Task AddPriceDetailsAsync(PriceDetails[] PriceDetailss)
        {
            await base.AddAsync(PriceDetailss);
        }

        public PriceDetails[] AddPriceDetails(PriceDetails[] PriceDetailss)
        {
            return base.Add(PriceDetailss);
        }

        public PriceDetails GetPriceDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, PriceDetails> GetPriceDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public PriceDetails[] GetPriceDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public PriceDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public PriceDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new PriceDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(PriceDetails item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.Currency,
                item.Price,
                item.Size,
                item.Unit,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public PriceDetails[] UpdatePriceDetails(PriceDetails[] PriceDetailss)
        {
            if (PriceDetailss.Any())
            {
                base.Update(PriceDetailss);
            }

            return PriceDetailss;
        }

        public PriceDetails[] DeletePriceDetails(PriceDetails[] PriceDetailss)
        {
            if (PriceDetailss.Any())
            {
                base.DeleteByDbId(PriceDetailss.Select(x => x.Id.ToString()).ToArray());
            }

            return PriceDetailss;
        }
    }
}
