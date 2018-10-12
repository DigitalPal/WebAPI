using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class DispatchRepository : IDispatchRepository
    {
        private IDispatchDA _DispatchDA;
        private IDispatchDetailsDA _DispatchDetailsDA;

        public DispatchRepository(IDispatchDA DispatchDA, IDispatchDetailsDA DispatchDetailsDA)
        {
            _DispatchDA = DispatchDA;
            _DispatchDetailsDA = DispatchDetailsDA;
        }

        public async Task AddDispatchAsync(Dispatch[] Dispatchs)
        {
            await _DispatchDA.AddDispatchAsync(Dispatchs);
        }
        public Dispatch[] AddDispatch(Dispatch[] Dispatchs)
        {
            foreach (Dispatch dispatch in Dispatchs)
            {
                dispatch.Id = Guid.NewGuid();
                _DispatchDA.AddDispatch(new[] { dispatch });
                foreach (DispatchDetails dispatchDetails in dispatch.DispatchDetails)
                {
                    dispatchDetails.DispatchId = dispatch.Id;
                    dispatchDetails.TenantId = dispatch.TenantId;
                    dispatchDetails.PlantId = dispatch.PlantId;
                }
                _DispatchDetailsDA.AddDispatchDetails(dispatch.DispatchDetails.ToArray());
            }

            return Dispatchs;
        }

        public Dispatch GetDispatch(string id)
        {
            return _DispatchDA.GetDispatch(id);
        }

        public Dictionary<string, Dispatch> GetDispatch(string[] ids)
        {
            return _DispatchDA.GetDispatch(ids);
        }

        public Dispatch[] GetDispatch(IEnumerable<Guid?> ids)
        {
            return _DispatchDA.GetDispatch(ids);
        }

        public Dispatch[] GetAll()
        {
            return _DispatchDA.GetAll();
        }


        public Dispatch[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _DispatchDA.GetByIds(Ids);
        }

        public Dispatch[] UpdateDispatch(Dispatch[] Dispatchs)
        {
            return _DispatchDA.UpdateDispatch(Dispatchs);
        }

        public Dispatch[] DeleteDispatch(string id)
        {
            return _DispatchDA.DeleteDispatch(id);
        }
    }
}
