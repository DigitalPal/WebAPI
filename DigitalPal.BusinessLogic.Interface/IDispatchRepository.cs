using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IDispatchRepository
    {
        Task AddDispatchAsync(Dispatch[] Dispatchs);
        Dispatch[] AddDispatch(Dispatch[] Dispatchs);

        Dispatch GetDispatch(string id);

        Dictionary<string, Dispatch> GetDispatch(string[] ids);

        Dispatch[] GetDispatch(IEnumerable<Guid?> ids);

        Dispatch[] GetAll();

        Dispatch[] GetByIds(IEnumerable<Guid> Ids);

        Dispatch[] UpdateDispatch(Dispatch[] Dispatchs);

        Dispatch DeleteDispatch(string id);
    }
}
