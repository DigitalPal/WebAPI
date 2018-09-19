using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class RawMaterialConsumptionRepository : IRawMaterialConsumptionRepository
    {
        private IRawMaterialConsumptionDA _RawMaterialConsumptionDA;

        public RawMaterialConsumptionRepository(IRawMaterialConsumptionDA RawMaterialConsumptionDA)
        {
            _RawMaterialConsumptionDA = RawMaterialConsumptionDA;
        }

        public async Task AddRawMaterialConsumptionAsync(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            await _RawMaterialConsumptionDA.AddRawMaterialConsumptionAsync(RawMaterialConsumptions);
        }
        public RawMaterialConsumption[] AddRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            return _RawMaterialConsumptionDA.AddRawMaterialConsumptions(RawMaterialConsumptions);
        }

        public RawMaterialConsumption GetRawMaterialConsumption(string id)
        {
            return _RawMaterialConsumptionDA.GetRawMaterialConsumption(id);
        }

        public Dictionary<string, RawMaterialConsumption> GetRawMaterialConsumptions(string[] ids)
        {
            return _RawMaterialConsumptionDA.GetRawMaterialConsumptions(ids);
        }

        public RawMaterialConsumption[] GetRawMaterialConsumptions(IEnumerable<Guid?> ids)
        {
            return _RawMaterialConsumptionDA.GetRawMaterialConsumptions(ids);
        }

        public RawMaterialConsumption[] GetAll()
        {
            return _RawMaterialConsumptionDA.GetAll();
        }


        public RawMaterialConsumption[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _RawMaterialConsumptionDA.GetByIds(Ids);
        }

        public RawMaterialConsumption[] UpdateRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            return _RawMaterialConsumptionDA.UpdateRawMaterialConsumptions(RawMaterialConsumptions);
        }

        public RawMaterialConsumption[] DeleteRawMaterialConsumptions(RawMaterialConsumption[] RawMaterialConsumptions)
        {
            return _RawMaterialConsumptionDA.DeleteRawMaterialConsumptions(RawMaterialConsumptions);
        }
    }
}
