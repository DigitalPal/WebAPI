using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IProductionDetailsDA
    {
        Task AddProductionDetailsAsync(ProductionDetails[] ProductionDetailss);
        ProductionDetails[] AddProductionDetails(ProductionDetails[] ProductionDetailss);

        ProductionDetails GetProductionDetails(string id);

        Dictionary<string, ProductionDetails> GetProductionDetails(string[] ids);

        ProductionDetails[] GetProductionDetails(IEnumerable<Guid?> ids);

        ProductionDetails[] GetAll();

        ProductionDetails[] GetByIds(IEnumerable<Guid> Ids);

        ProductionDetails[] UpdateProductionDetails(ProductionDetails[] ProductionDetailss);

        ProductionDetails[] DeleteProductionDetails(ProductionDetails[] ProductionDetailss);
    }
}
