using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IRawMaterialConsumptionDA
    {
        Task AddRawMaterialConsumptionAsync(RawMaterialConsumption[] RawMaterialConsumptions);
        RawMaterialConsumption[] AddRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions);

        RawMaterialConsumption GetRawMaterialConsumption(string id);

        Dictionary<string, RawMaterialConsumption> GetRawMaterialConsumptions(string[] ids);

        RawMaterialConsumption[] GetRawMaterialConsumptions(IEnumerable<Guid?> ids);

        RawMaterialConsumption[] GetAll();

        RawMaterialConsumption[] GetByIds(IEnumerable<Guid> Ids);

        RawMaterialConsumption[] UpdateRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions);

        RawMaterialConsumption[] DeleteRawMaterialConsumptions(string id);
    }
}
