using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class ConsumptionRepository : IConsumptionRepository
    {
        private IConsumptionDA _ConsumptionDA;

        public ConsumptionRepository(IConsumptionDA ConsumptionDA)
        {
            _ConsumptionDA = ConsumptionDA;
        }

        public async Task AddConsumptionAsync(Consumption[] Consumptions)
        {
            await _ConsumptionDA.AddConsumptionAsync(Consumptions);
        }
        public Consumption[] AddConsumptions(Consumption[] Consumptions)
        {
            return _ConsumptionDA.AddConsumptions(Consumptions);
        }

        public Consumption GetConsumption(string id)
        {
            return _ConsumptionDA.GetConsumption(id);
        }

        public Dictionary<string, Consumption> GetConsumptions(string[] ids)
        {
            return _ConsumptionDA.GetConsumptions(ids);
        }

        public Consumption[] GetConsumptions(IEnumerable<Guid?> ids)
        {
            return _ConsumptionDA.GetConsumptions(ids);
        }

        public Consumption[] GetAll()
        {
            return _ConsumptionDA.GetAll();
        }


        public Consumption[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _ConsumptionDA.GetByIds(Ids);
        }

        public Consumption[] UpdateConsumptions(Consumption[] Consumptions)
        {
            return _ConsumptionDA.UpdateConsumptions(Consumptions);
        }

        public Consumption[] DeleteConsumptions(string id)
        {
            return _ConsumptionDA.DeleteConsumptions(id);
        }

        public ConsumptionReport[] Search(ConsumptionReport consumptionReport)
        {
            return _ConsumptionDA.Search(consumptionReport);
        }
    }
}
