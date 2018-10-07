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

        public DispatchRepository(IDispatchDA DispatchDA)
        {
            _DispatchDA = DispatchDA;
        }

        public async Task AddDispatchAsync(Dispatch[] Dispatchs)
        {
            await _DispatchDA.AddDispatchAsync(Dispatchs);
        }
        public Dispatch[] AddDispatch(Dispatch[] Dispatchs)
        {
            return _DispatchDA.AddDispatch(Dispatchs);
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
