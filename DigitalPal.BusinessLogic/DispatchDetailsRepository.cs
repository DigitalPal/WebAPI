using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class DispatchDetailsRepository : IDispatchDetailsRepository
    {
        private IDispatchDetailsDA _DispatchDetailsDA;

        public DispatchDetailsRepository(IDispatchDetailsDA DispatchDetailsDA)
        {
            _DispatchDetailsDA = DispatchDetailsDA;
        }

        public async Task AddDispatchDetailsAsync(DispatchDetails[] DispatchDetailss)
        {
            await _DispatchDetailsDA.AddDispatchDetailsAsync(DispatchDetailss);
        }
        public DispatchDetails[] AddDispatchDetails(DispatchDetails[] DispatchDetailss)
        {
            return _DispatchDetailsDA.AddDispatchDetails(DispatchDetailss);
        }

        public DispatchDetails GetDispatchDetails(string id)
        {
            return _DispatchDetailsDA.GetDispatchDetails(id);
        }

        public Dictionary<string, DispatchDetails> GetDispatchDetails(string[] ids)
        {
            return _DispatchDetailsDA.GetDispatchDetails(ids);
        }

        public DispatchDetails[] GetDispatchDetails(IEnumerable<Guid?> ids)
        {
            return _DispatchDetailsDA.GetDispatchDetails(ids);
        }

        public DispatchDetails[] GetAll()
        {
            return _DispatchDetailsDA.GetAll();
        }


        public DispatchDetails[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _DispatchDetailsDA.GetByIds(Ids);
        }

        public DispatchDetails[] UpdateDispatchDetails(DispatchDetails[] DispatchDetailss)
        {
            return _DispatchDetailsDA.UpdateDispatchDetails(DispatchDetailss);
        }

        public DispatchDetails[] DeleteDispatchDetails(DispatchDetails[] DispatchDetailss)
        {
            return _DispatchDetailsDA.DeleteDispatchDetails(DispatchDetailss);
        }
    }
}
