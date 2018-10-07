using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private IInvoiceDA _InvoiceDA;

        public InvoiceRepository(IInvoiceDA InvoiceDA)
        {
            _InvoiceDA = InvoiceDA;
        }

        public async Task AddInvoiceAsync(Invoice[] Invoices)
        {
            await _InvoiceDA.AddInvoiceAsync(Invoices);
        }
        public Invoice[] AddInvoices(Invoice[] Invoices)
        {
            return _InvoiceDA.AddInvoices(Invoices);
        }

        public Invoice GetInvoice(string id)
        {
            return _InvoiceDA.GetInvoice(id);
        }

        public Dictionary<string, Invoice> GetInvoices(string[] ids)
        {
            return _InvoiceDA.GetInvoices(ids);
        }

        public Invoice[] GetInvoices(IEnumerable<Guid?> ids)
        {
            return _InvoiceDA.GetInvoices(ids);
        }

        public Invoice[] GetAll()
        {
            return _InvoiceDA.GetAll();
        }


        public Invoice[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _InvoiceDA.GetByIds(Ids);
        }

        public Invoice[] UpdateInvoices(Invoice[] Invoices)
        {
            return _InvoiceDA.UpdateInvoices(Invoices);
        }

        public Invoice[] DeleteInvoices(string id)
        {
            return _InvoiceDA.DeleteInvoices(id);
        }
    }
}
