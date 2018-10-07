using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class PaymentRepository : IPaymentRepository
    {
        private IPaymentDA _PaymentDA;

        public PaymentRepository(IPaymentDA PaymentDA)
        {
            _PaymentDA = PaymentDA;
        }

        public async Task AddPaymentAsync(Payment[] Payments)
        {
            await _PaymentDA.AddPaymentAsync(Payments);
        }
        public Payment[] AddPayments(Payment[] Payments)
        {
            return _PaymentDA.AddPayments(Payments);
        }

        public Payment GetPayment(string id)
        {
            return _PaymentDA.GetPayment(id);
        }

        public Dictionary<string, Payment> GetPayments(string[] ids)
        {
            return _PaymentDA.GetPayments(ids);
        }

        public Payment[] GetPayments(IEnumerable<Guid?> ids)
        {
            return _PaymentDA.GetPayments(ids);
        }

        public Payment[] GetAll()
        {
            return _PaymentDA.GetAll();
        }


        public Payment[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _PaymentDA.GetByIds(Ids);
        }

        public Payment[] UpdatePayments(Payment[] Payments)
        {
            return _PaymentDA.UpdatePayments(Payments);
        }

        public Payment[] DeletePayments(string id)
        {
            return _PaymentDA.DeletePayments(id);
        }
    }
}
