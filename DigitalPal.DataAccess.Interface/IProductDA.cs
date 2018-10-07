using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IProductDA
    {
        Task AddProductAsync(Product[] Products);
        Product[] AddProducts(Product[] Products);

        Product GetProduct(string id);

        Dictionary<string, Product> GetProducts(string[] ids);

        Product[] GetProducts(IEnumerable<Guid?> ids);

        Product[] GetAll();

        Product[] GetByIds(IEnumerable<Guid> Ids);

        Product[] UpdateProducts(Product[] Products);

        Product[] DeleteProducts(string id);
    }
}
