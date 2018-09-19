using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IPriceDetailsDA
    {
        Task AddPriceDetailsAsync(PriceDetails[] PriceDetailss);
        PriceDetails[] AddPriceDetails(PriceDetails[] PriceDetailss);

        PriceDetails GetPriceDetails(string id);

        Dictionary<string, PriceDetails> GetPriceDetails(string[] ids);

        PriceDetails[] GetPriceDetails(IEnumerable<Guid?> ids);

        PriceDetails[] GetAll();

        PriceDetails[] GetByIds(IEnumerable<Guid> Ids);

        PriceDetails[] UpdatePriceDetails(PriceDetails[] PriceDetailss);

        PriceDetails[] DeletePriceDetails(PriceDetails[] PriceDetailss);
    }
}
