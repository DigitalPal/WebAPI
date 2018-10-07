using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IInvoiceRepository
    {
        Task AddInvoiceAsync(Invoice[] Invoices);
        Invoice[] AddInvoices(Invoice[] Invoices);

        Invoice GetInvoice(string id);

        Dictionary<string, Invoice> GetInvoices(string[] ids);

        Invoice[] GetInvoices(IEnumerable<Guid?> ids);

        Invoice[] GetAll();

        Invoice[] GetByIds(IEnumerable<Guid> Ids);

        Invoice[] UpdateInvoices(Invoice[] Invoices);

        Invoice[] DeleteInvoices(string id);
    }
}
