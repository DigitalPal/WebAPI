using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IRawMaterialDetailsRepository
    {
        Task AddRawMaterialDetailsAsync(RawMaterialDetails[] RawMaterialDetailss);
        RawMaterialDetails[] AddRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss);

        RawMaterialDetails GetRawMaterialDetails(string id);

        Dictionary<string, RawMaterialDetails> GetRawMaterialDetails(string[] ids);

        RawMaterialDetails[] GetRawMaterialDetails(IEnumerable<Guid?> ids);

        RawMaterialDetails[] GetAll();

        RawMaterialDetails[] GetByIds(IEnumerable<Guid> Ids);

        RawMaterialDetails[] UpdateRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss);

        RawMaterialDetails[] DeleteRawMaterialDetails(RawMaterialDetails[] RawMaterialDetailss);
    }
}
