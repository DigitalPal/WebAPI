using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class PriceDetailsRepository : IPriceDetailsRepository
    {
        private IPriceDetailsDA _PriceDetailsDA;

        public PriceDetailsRepository(IPriceDetailsDA PriceDetailsDA)
        {
            _PriceDetailsDA = PriceDetailsDA;
        }

        public async Task AddPriceDetailsAsync(PriceDetails[] PriceDetailss)
        {
            await _PriceDetailsDA.AddPriceDetailsAsync(PriceDetailss);
        }
        public PriceDetails[] AddPriceDetails(PriceDetails[] PriceDetailss)
        {
            return _PriceDetailsDA.AddPriceDetails(PriceDetailss);
        }

        public PriceDetails GetPriceDetails(string id)
        {
            return _PriceDetailsDA.GetPriceDetails(id);
        }

        public Dictionary<string, PriceDetails> GetPriceDetails(string[] ids)
        {
            return _PriceDetailsDA.GetPriceDetails(ids);
        }

        public PriceDetails[] GetPriceDetails(IEnumerable<Guid?> ids)
        {
            return _PriceDetailsDA.GetPriceDetails(ids);
        }

        public PriceDetails[] GetAll()
        {
            return _PriceDetailsDA.GetAll();
        }


        public PriceDetails[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _PriceDetailsDA.GetByIds(Ids);
        }

        public PriceDetails[] UpdatePriceDetails(PriceDetails[] PriceDetailss)
        {
            return _PriceDetailsDA.UpdatePriceDetails(PriceDetailss);
        }

        public PriceDetails[] DeletePriceDetails(PriceDetails[] PriceDetailss)
        {
            return _PriceDetailsDA.DeletePriceDetails(PriceDetailss);
        }
    }
}
