using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IDispatchDetailsDA
    {
        Task AddDispatchDetailsAsync(DispatchDetails[] DispatchDetailss);
        DispatchDetails[] AddDispatchDetails(DispatchDetails[] DispatchDetailss);

        DispatchDetails GetDispatchDetails(string id);

        Dictionary<string, DispatchDetails> GetDispatchDetails(string[] ids);

        DispatchDetails[] GetDispatchDetails(IEnumerable<Guid?> ids);

        DispatchDetails[] GetAll();

        DispatchDetails[] GetByIds(IEnumerable<Guid> Ids);

        DispatchDetails[] UpdateDispatchDetails(DispatchDetails[] DispatchDetailss);

        DispatchDetails[] DeleteDispatchDetails(string id);
    }
}
