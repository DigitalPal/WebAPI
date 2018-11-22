using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IConsumptionDA
    {
        Task AddConsumptionAsync(Consumption[] Consumptions);
        Consumption[] AddConsumptions(Consumption[] Consumptions);

        Consumption GetConsumption(string id);

        Dictionary<string, Consumption> GetConsumptions(string[] ids);

        Consumption[] GetConsumptions(IEnumerable<Guid?> ids);

        Consumption[] GetAll();

        Consumption[] GetByIds(IEnumerable<Guid> Ids);

        Consumption[] UpdateConsumptions(Consumption[] Consumptions);

        Consumption[] DeleteConsumptions(string id);

        ConsumptionReport[] Search(ConsumptionReport consumption);
    }
}
