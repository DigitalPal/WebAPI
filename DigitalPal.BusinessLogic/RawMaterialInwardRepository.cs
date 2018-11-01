using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class RawMaterialInwardRepository : IRawMaterialInwardRepository
    {
        private IRawMaterialInwardDA _RawMaterialInwardDA;

        public RawMaterialInwardRepository(IRawMaterialInwardDA RawMaterialInwardDA)
        {
            _RawMaterialInwardDA = RawMaterialInwardDA;
        }

        public async Task AddRawMaterialInwardAsync(RawMaterialInward[] RawMaterialInwards)
        {
            await _RawMaterialInwardDA.AddRawMaterialInwardAsync(RawMaterialInwards);
        }
        public RawMaterialInward[] AddRawMaterialInwards(RawMaterialInward[] RawMaterialInwards)
        {
            return _RawMaterialInwardDA.AddRawMaterialInwards(RawMaterialInwards);
        }

        public RawMaterialInward[] Search(RawMaterialInward RawMaterialInward)
        {
            return _RawMaterialInwardDA.Search(RawMaterialInward);
        }

        public RawMaterialInward GetRawMaterialInward(string id)
        {
            return _RawMaterialInwardDA.GetRawMaterialInward(id);
        }

        public Dictionary<string, RawMaterialInward> GetRawMaterialInwards(string[] ids)
        {
            return _RawMaterialInwardDA.GetRawMaterialInwards(ids);
        }

        public RawMaterialInward[] GetRawMaterialInwards(IEnumerable<Guid?> ids)
        {
            return _RawMaterialInwardDA.GetRawMaterialInwards(ids);
        }

        public RawMaterialInward[] GetAll()
        {
            return _RawMaterialInwardDA.GetAll();
        }


        public RawMaterialInward[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _RawMaterialInwardDA.GetByIds(Ids);
        }

        public RawMaterialInward[] UpdateRawMaterialInwards(RawMaterialInward[] RawMaterialInwards)
        {
            return _RawMaterialInwardDA.UpdateRawMaterialInwards(RawMaterialInwards);
        }

        public RawMaterialInward[] DeleteRawMaterialInwards(string id)
        {
            return _RawMaterialInwardDA.DeleteRawMaterialInwards(id);
        }
    }
}
