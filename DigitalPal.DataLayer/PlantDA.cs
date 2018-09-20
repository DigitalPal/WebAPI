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
    public class PlantDA : DataAccessBase<Plant>, IPlantDA
    {

        public PlantDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Plant;
        }

        public async Task AddPlantAsync(Plant[] Plants)
        {
            await base.AddAsync(Plants);
        }

        public Plant[] AddPlants(Plant[] Plants)
        {
            return base.Add(Plants);
        }

        public Plant GetPlant(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Plant> GetPlants(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Plant[] GetPlants(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Plant[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Plant[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new Plant()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Plant item)
        {
            return new
            {
                item.Id,
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.Address,
                item.AdminUser,
                item.ContactNumber,
                item.Logo,
                item.CreatedBy,
                item.ModifiedBy
            };
        }

        public Plant[] UpdatePlants(Plant[] Plants)
        {
            if (Plants.Any())
            {
                base.Update(Plants);
            }

            return Plants;
        }

        public Plant[] DeletePlants(Plant[] Plants)
        {
            if (Plants.Any())
            {
                base.DeleteByDbId(Plants.Select(x => x.Id.ToString()).ToArray());
            }

            return Plants;
        }
    }
}
