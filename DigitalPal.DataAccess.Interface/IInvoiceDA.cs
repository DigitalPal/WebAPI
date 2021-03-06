﻿using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IInvoiceDA
    {
        Task AddInvoiceAsync(Invoice[] Invoices);
        Invoice[] AddInvoices(Invoice[] Invoices);

        Invoice GetInvoice(string id);

        InvoiceDetailInfo GetInvoiceDetailInformationByInvoiceId(string invoiceId);

        Dictionary<string, Invoice> GetInvoices(string[] ids);

        Invoice[] GetInvoices(IEnumerable<Guid?> ids);

        Invoice[] GetAll();

        Invoice[] GetByIds(IEnumerable<Guid> Ids);

        Invoice[] UpdateInvoices(Invoice[] Invoices);

        Invoice[] DeleteInvoices(string id);
    }
}
