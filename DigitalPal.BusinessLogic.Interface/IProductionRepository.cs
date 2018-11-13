using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IProductionRepository
    {
        Task AddProductionAsync(Production[] Productions);
        Production[] AddProduction(Production[] Productions);

        Production GetProduction(string id);

        Dictionary<string, Production> GetProduction(string[] ids);

        Production[] GetProduction(IEnumerable<Guid?> ids);

        Production[] GetAll();

        Production[] GetByIds(IEnumerable<Guid> Ids);

        Production[] UpdateProduction(Production[] Productions);

        Production[] DeleteProduction(string id);

        ProductionReport[] Search(ProductionReport productionReport);
    }
}
