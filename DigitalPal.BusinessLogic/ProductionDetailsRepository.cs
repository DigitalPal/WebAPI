using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class ProductionDetailsRepository : IProductionDetailsRepository
    {
        private IProductionDetailsDA _ProductionDetailsDA;

        public ProductionDetailsRepository(IProductionDetailsDA ProductionDetailsDA)
        {
            _ProductionDetailsDA = ProductionDetailsDA;
        }

        public ProductionDetails[] Search(ProductionDetails ProductionDetails)
        {
            return _ProductionDetailsDA.Search(ProductionDetails);
        }

        public async Task AddProductionDetailsAsync(ProductionDetails[] ProductionDetailss)
        {
            await _ProductionDetailsDA.AddProductionDetailsAsync(ProductionDetailss);
        }
        public ProductionDetails[] AddProductionDetails(ProductionDetails[] ProductionDetailss)
        {
            return _ProductionDetailsDA.AddProductionDetails(ProductionDetailss);
        }

        public ProductionDetails GetProductionDetails(string id)
        {
            return _ProductionDetailsDA.GetProductionDetails(id);
        }

        public Dictionary<string, ProductionDetails> GetProductionDetails(string[] ids)
        {
            return _ProductionDetailsDA.GetProductionDetails(ids);
        }

        public ProductionDetails[] GetProductionDetails(IEnumerable<Guid?> ids)
        {
            return _ProductionDetailsDA.GetProductionDetails(ids);
        }

        public ProductionDetails[] GetAll()
        {
            return _ProductionDetailsDA.GetAll();
        }


        public ProductionDetails[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ProductionDetailsDA.GetByIds(Ids);
        }

        public ProductionDetails[] UpdateProductionDetails(ProductionDetails[] ProductionDetailss)
        {
            return _ProductionDetailsDA.UpdateProductionDetails(ProductionDetailss);
        }

        public ProductionDetails[] DeleteProductionDetails(string id)
        {
            return _ProductionDetailsDA.DeleteProductionDetails(id);
        }
    }
}
