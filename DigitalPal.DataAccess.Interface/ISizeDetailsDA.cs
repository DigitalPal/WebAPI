using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface ISizeDetailsDA
    {
        Task AddSizeDetailsAsync(SizeDetails[] SizeDetailss);
        SizeDetails[] AddSizeDetails(SizeDetails[] SizeDetailss);

        SizeDetails GetSizeDetails(string id);

        Dictionary<string, SizeDetails> GetSizeDetails(string[] ids);

        SizeDetails[] GetSizeDetails(IEnumerable<Guid?> ids);

        SizeDetails[] GetAll();

        SizeDetails[] GetByIds(IEnumerable<Guid> Ids);

        SizeDetails[] UpdateSizeDetails(SizeDetails[] SizeDetailss);

        SizeDetails[] DeleteSizeDetails(string id);
    }
}
