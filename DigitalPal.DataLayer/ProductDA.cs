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
    public class ProductDA : DataAccessBase<Product>, IProductDA
    {

        public ProductDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Product;
        }

        public async Task AddProductAsync(Product[] Products)
        {
            await base.AddAsync(Products);
        }

        public Product[] AddProducts(Product[] Products)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                Products[i].Id = Guid.NewGuid();
            }

            return base.Add(Products);
        }

        public Product GetProduct(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Product> GetProducts(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Product[] GetProducts(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Product[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Product[] GetByIds(IEnumerable<Guid> Ids)
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
            PropertyInfo[] props = Mapping(new Product()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Product item)
        {
            return new
            {
                item.Id,
                item.Name,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                //item.Currency,
                item.PlantId,
                item.Price,
                item.Size,
                //item.Unit,
                item.Length,
                item.Width,
                item.Height,
                item.HSNCode
            };
        }

        public Product[] UpdateProducts(Product[] Products)
        {
            if (Products.Any())
            {
                base.Update(Products);
            }

            return Products;
        }

        public Product[] DeleteProducts(string id)
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
