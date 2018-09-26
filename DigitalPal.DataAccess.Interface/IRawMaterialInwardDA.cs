using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IRawMaterialInwardDA
    {
        Task AddRawMaterialInwardAsync(RawMaterialInward[] RawMaterialInwards);
        RawMaterialInward[] AddRawMaterialInwards(RawMaterialInward[] RawMaterialInwards);

        RawMaterialInward GetRawMaterialInward(string id);

        Dictionary<string, RawMaterialInward> GetRawMaterialInwards(string[] ids);

        RawMaterialInward[] GetRawMaterialInwards(IEnumerable<Guid?> ids);

        RawMaterialInward[] GetAll();

        RawMaterialInward[] GetByIds(IEnumerable<Guid> Ids);

        RawMaterialInward[] UpdateRawMaterialInwards(RawMaterialInward[] RawMaterialInwards);

        RawMaterialInward[] DeleteRawMaterialInwards(string id);
    }
}
