using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class ProductRepository : IProductRepository
    {
        private IProductDA _ProductDA;

        public ProductRepository(IProductDA ProductDA)
        {
            _ProductDA = ProductDA;
        }

        public async Task AddProductAsync(Product[] Products)
        {
            await _ProductDA.AddProductAsync(Products);
        }
        public Product[] AddProducts(Product[] Products)
        {
            return _ProductDA.AddProducts(Products);
        }

        public Product GetProduct(string id)
        {
            return _ProductDA.GetProduct(id);
        }

        public Dictionary<string, Product> GetProducts(string[] ids)
        {
            return _ProductDA.GetProducts(ids);
        }

        public Product[] GetProducts(IEnumerable<Guid?> ids)
        {
            return _ProductDA.GetProducts(ids);
        }

        public Product[] GetAll()
        {
            return _ProductDA.GetAll();
        }


        public Product[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ProductDA.GetByIds(Ids);
        }

        public Product[] UpdateProducts(Product[] Products)
        {
            return _ProductDA.UpdateProducts(Products);
        }

        public Product[] DeleteProducts(string id)
        {
            return _ProductDA.DeleteProducts(id);
        }
    }
}
