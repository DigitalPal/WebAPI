using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class SizeDetailsRepository : ISizeDetailsRepository
    {
        private ISizeDetailsDA _SizeDetailsDA;

        public SizeDetailsRepository(ISizeDetailsDA SizeDetailsDA)
        {
            _SizeDetailsDA = SizeDetailsDA;
        }

        public async Task AddSizeDetailsAsync(SizeDetails[] SizeDetailss)
        {
            await _SizeDetailsDA.AddSizeDetailsAsync(SizeDetailss);
        }
        public SizeDetails[] AddSizeDetails(SizeDetails[] SizeDetailss)
        {
            return _SizeDetailsDA.AddSizeDetails(SizeDetailss);
        }

        public SizeDetails GetSizeDetails(string id)
        {
            return _SizeDetailsDA.GetSizeDetails(id);
        }

        public Dictionary<string, SizeDetails> GetSizeDetails(string[] ids)
        {
            return _SizeDetailsDA.GetSizeDetails(ids);
        }

        public SizeDetails[] GetSizeDetails(IEnumerable<Guid?> ids)
        {
            return _SizeDetailsDA.GetSizeDetails(ids);
        }

        public SizeDetails[] GetAll()
        {
            return _SizeDetailsDA.GetAll();
        }


        public SizeDetails[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _SizeDetailsDA.GetByIds(Ids);
        }

        public SizeDetails[] UpdateSizeDetails(SizeDetails[] SizeDetailss)
        {
            return _SizeDetailsDA.UpdateSizeDetails(SizeDetailss);
        }

        public SizeDetails[] DeleteSizeDetails(SizeDetails[] SizeDetailss)
        {
            return _SizeDetailsDA.DeleteSizeDetails(SizeDetailss);
        }
    }
}
