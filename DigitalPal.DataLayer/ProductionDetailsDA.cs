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
    public class ProductionDetailsDA : DataAccessBase<ProductionDetails>, IProductionDetailsDA
    {

        public ProductionDetailsDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_ProductionDetails;
        }

        public async Task AddProductionDetailsAsync(ProductionDetails[] ProductionDetailss)
        {
            await base.AddAsync(ProductionDetailss);
        }

        public ProductionDetails[] AddProductionDetails(ProductionDetails[] ProductionDetailss)
        {
            return base.Add(ProductionDetailss);
        }

        public ProductionDetails GetProductionDetails(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, ProductionDetails> GetProductionDetails(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public ProductionDetails[] GetProductionDetails(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public ProductionDetails[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public ProductionDetails[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new ProductionDetails()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(ProductionDetails item)
        {
            return new
            {
                item.Id,
                item.Breakage,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.NoOfMouldsCasted,
                item.ProductionDate,
                item.Quantity,
                item.Remark,
                item.Size,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.PlantId
            };
        }

        public ProductionDetails[] UpdateProductionDetails(ProductionDetails[] ProductionDetailss)
        {
            if (ProductionDetailss.Any())
            {
                base.Update(ProductionDetailss);
            }

            return ProductionDetailss;
        }

        public ProductionDetails[] DeleteProductionDetails(ProductionDetails[] ProductionDetailss)
        {
            if (ProductionDetailss.Any())
            {
                base.DeleteByDbId(ProductionDetailss.Select(x => x.Id.ToString()).ToArray());
            }

            return ProductionDetailss;
        }
    }
}
