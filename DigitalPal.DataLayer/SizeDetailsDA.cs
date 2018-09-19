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
    public class SizeDetailsDA : DataAccessBase<SizeDetails>, ISizeDetailsDA
    {

        public SizeDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_SizeDetails;
        }

        public async Task AddSizeDetailsAsync(SizeDetails[] SizeDetailss)
        {
            await base.AddAsync(SizeDetailss);
        }

        public SizeDetails[] AddSizeDetails(SizeDetails[] SizeDetailss)
        {
            return base.Add(SizeDetailss);
        }

        public SizeDetails GetSizeDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, SizeDetails> GetSizeDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public SizeDetails[] GetSizeDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public SizeDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public SizeDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new SizeDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(SizeDetails item)
        {
            return new
            {
                item.Id,
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.ConversionFactor,
                item.Size
            };
        }

        public SizeDetails[] UpdateSizeDetails(SizeDetails[] SizeDetailss)
        {
            if (SizeDetailss.Any())
            {
                base.Update(SizeDetailss);
            }

            return SizeDetailss;
        }

        public SizeDetails[] DeleteSizeDetails(SizeDetails[] SizeDetailss)
        {
            if (SizeDetailss.Any())
            {
                base.DeleteByDbId(SizeDetailss.Select(x => x.Id.ToString()).ToArray());
            }

            return SizeDetailss;
        }
    }
}
