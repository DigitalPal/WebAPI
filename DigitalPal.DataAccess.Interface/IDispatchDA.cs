using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IDispatchDA
    {
        Task AddDispatchAsync(Dispatch[] Dispatchs);
        Dispatch[] AddDispatch(Dispatch[] Dispatchs);

        Dispatch GetDispatch(string id);

        Dictionary<string, Dispatch> GetDispatch(string[] ids);

        Dispatch[] GetDispatch(IEnumerable<Guid?> ids);

        Dispatch[] GetAll();

        Dispatch[] GetByIds(IEnumerable<Guid> Ids);

        Dispatch[] UpdateDispatch(Dispatch[] Dispatchs);

        void DeleteDispatch(string id);
    }
}
