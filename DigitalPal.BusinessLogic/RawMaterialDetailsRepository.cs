using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class RawMaterialDetailsRepository : IRawMaterialDetailsRepository
    {
        private IRawMaterialDetailsDA _RawMaterialDetailsDA;

        public RawMaterialDetailsRepository(IRawMaterialDetailsDA RawMaterialDetailsDA)
        {
            _RawMaterialDetailsDA = RawMaterialDetailsDA;
        }

        public async Task AddRawMaterialDetailsAsync(RawMaterialDetails[] RawMaterialDetailss)
        {
            await _RawMaterialDetailsDA.AddRawMaterialDetailsAsync(RawMaterialDetailss);
        }
        public RawMaterialDetails[] AddRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss)
        {
            return _RawMaterialDetailsDA.AddRawMaterialDetails(RawMaterialDetailss);
        }

        public RawMaterialDetails GetRawMaterialDetails(string id)
        {
            return _RawMaterialDetailsDA.GetRawMaterialDetails(id);
        }

        public Dictionary<string, RawMaterialDetails> GetRawMaterialDetails(string[] ids)
        {
            return _RawMaterialDetailsDA.GetRawMaterialDetails(ids);
        }

        public RawMaterialDetails[] GetRawMaterialDetails(IEnumerable<Guid?> ids)
        {
            return _RawMaterialDetailsDA.GetRawMaterialDetails(ids);
        }

        public RawMaterialDetails[] GetAll()
        {
            return _RawMaterialDetailsDA.GetAll();
        }


        public RawMaterialDetails[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _RawMaterialDetailsDA.GetByIds(Ids);
        }

        public RawMaterialDetails[] UpdateRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss)
        {
            return _RawMaterialDetailsDA.UpdateRawMaterialDetails(RawMaterialDetailss);
        }

        public RawMaterialDetails[] DeleteRawMaterialDetails(string id)
        {
            return _RawMaterialDetailsDA.DeleteRawMaterialDetails(id);
        }
    }
}
