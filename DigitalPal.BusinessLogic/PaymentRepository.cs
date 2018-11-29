using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class PaymentRepository : IPaymentRepository
    {
        private IPaymentDA _PaymentDA;
        private IInvoiceDA _InvoiceDA;

        public PaymentRepository(IPaymentDA PaymentDA, IInvoiceDA InvoiceDA)
        {
            _PaymentDA = PaymentDA;
            _InvoiceDA = InvoiceDA;
        }
        public Payment[] Search(Payment Payment)
        {
            return _PaymentDA.Search(Payment);
        }

        public async Task AddPaymentAsync(Payment[] Payments)
        {
            await _PaymentDA.AddPaymentAsync(Payments);
        }
        public Payment[] AddPayments(Payment[] Payments)
        {   
            _PaymentDA.AddPayments(Payments);
            List<Invoice> lstInvoice = new List<Invoice>();
            foreach (Payment payment in Payments)
            {
                Invoice objInvoice = _InvoiceDA.GetInvoice(payment.InvoiceId.ToString());
                if (objInvoice != null)
                {
                    objInvoice.CanDelete = false;
                    objInvoice.CanEdit = false;
                    lstInvoice.Add(objInvoice);
                }
            }
            //Update invoice, if entry in payment then set can edit can delete to false
            _InvoiceDA.UpdateInvoices(lstInvoice.GroupBy(p => p.Id).Select(grp => grp.FirstOrDefault()).ToArray());
            return Payments;
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
