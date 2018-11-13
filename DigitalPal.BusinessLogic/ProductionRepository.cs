using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class ProductionRepository : IProductionRepository
    {
        private IProductionDA _ProductionDA;
        private IProductionDetailsDA _ProductionDetailsDA;

        public ProductionRepository(IProductionDA ProductionDA, IProductionDetailsDA ProductionDetailsDA)
        {
            _ProductionDA = ProductionDA;
            _ProductionDetailsDA = ProductionDetailsDA;
        }

        public async Task AddProductionAsync(Production[] Productions)
        {
            await _ProductionDA.AddProductionAsync(Productions);
        }
        public Production[] AddProduction(Production[] Productions)
        {
            foreach (Production production in Productions)
            {
                production.Id = Guid.NewGuid();
                _ProductionDA.AddProduction(new[] { production });

                foreach (ProductionDetails productionDetails in production.ProductionDetails)
                {
                    productionDetails.Id = Guid.NewGuid();
                    productionDetails.ProductionId = production.Id;
                    productionDetails.TenantId = production.TenantId;
                    productionDetails.PlantId = production.PlantId;
                }

                _ProductionDetailsDA.AddProductionDetails(production.ProductionDetails.ToArray());
            }

            return Productions;
        }

        public Production GetProduction(string id)
        {
            return _ProductionDA.GetProduction(id);
        }

        public Dictionary<string, Production> GetProduction(string[] ids)
        {
            return _ProductionDA.GetProduction(ids);
        }

        public Production[] GetProduction(IEnumerable<Guid?> ids)
        {
            return _ProductionDA.GetProduction(ids);
        }

        public Production[] GetAll()
        {
            return _ProductionDA.GetAll();
        }


        public Production[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ProductionDA.GetByIds(Ids);
        }

        public Production[] UpdateProduction(Production[] Productions)
        {
            return _ProductionDA.UpdateProduction(Productions);
        }

        public Production[] DeleteProduction(string id)
        {
            //_ProductionDetailsDA.DeleteProductionDetails(id);
             _ProductionDA.DeleteProduction(id);
            return null;
        }

        public ProductionReport[] Search(ProductionReport productionReport)
        {
            return _ProductionDA.Search(productionReport);
        }
    }
}
