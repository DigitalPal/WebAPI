using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class SupplierPaymentRepository : ISupplierPaymentRepository
    {
        private ISupplierPaymentDA _SupplierPaymentDA;

        public SupplierPaymentRepository(ISupplierPaymentDA SupplierPaymentDA)
        {
            _SupplierPaymentDA = SupplierPaymentDA;
        }
        public SupplierPayment[] Search(SupplierPayment SupplierPayment)
        {
            return _SupplierPaymentDA.Search(SupplierPayment);
        }

        public async Task AddSupplierPaymentAsync(SupplierPayment[] SupplierPayments)
        {
            await _SupplierPaymentDA.AddSupplierPaymentAsync(SupplierPayments);
        }
        public SupplierPayment[] AddSupplierPayments(SupplierPayment[] SupplierPayments)
        {
            return _SupplierPaymentDA.AddSupplierPayments(SupplierPayments);
        }

        public SupplierPayment GetSupplierPayment(string id)
        {
            return _SupplierPaymentDA.GetSupplierPayment(id);
        }

        public Dictionary<string, SupplierPayment> GetSupplierPayments(string[] ids)
        {
            return _SupplierPaymentDA.GetSupplierPayments(ids);
        }

        public SupplierPayment[] GetSupplierPayments(IEnumerable<Guid?> ids)
        {
            return _SupplierPaymentDA.GetSupplierPayments(ids);
        }

        public SupplierPayment[] GetAll()
        {
            return _SupplierPaymentDA.GetAll();
        }


        public SupplierPayment[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _SupplierPaymentDA.GetByIds(Ids);
        }

        public SupplierPayment[] UpdateSupplierPayments(SupplierPayment[] SupplierPayments)
        {
            return _SupplierPaymentDA.UpdateSupplierPayments(SupplierPayments);
        }

        public SupplierPayment[] DeleteSupplierPayments(string id)
        {
            return _SupplierPaymentDA.DeleteSupplierPayments(id);
        }
    }
}
