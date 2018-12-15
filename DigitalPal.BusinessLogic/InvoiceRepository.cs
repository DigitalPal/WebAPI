using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private IInvoiceDA _InvoiceDA;
        private IDispatchDA _DispatchDA;

        public InvoiceRepository(IInvoiceDA InvoiceDA, IDispatchDA DispatchDA)
        {
            _InvoiceDA = InvoiceDA;
            _DispatchDA = DispatchDA;
        }

        public async Task AddInvoiceAsync(Invoice[] Invoices)
        {
            await _InvoiceDA.AddInvoiceAsync(Invoices);
        }

        public Invoice[] AddInvoices(Invoice[] Invoices)
        {
            _InvoiceDA.AddInvoices(Invoices);
            List<Dispatch> lstDispatch = new List<Dispatch>();
            foreach (Invoice Inv in Invoices)
            {
                Dispatch objDispatch = _DispatchDA.GetDispatch(Inv.DispatchId.ToString());
                if (objDispatch != null)
                {
                    objDispatch.CanDelete = false;
                    objDispatch.CanEdit = false;
                    lstDispatch.Add(objDispatch);
                }
            }
            //Update dispatch, if entry in invoide then set can edit can delete to false
            _DispatchDA.UpdateDispatch(lstDispatch.GroupBy(p => p.Id).Select(grp => grp.FirstOrDefault()).ToArray());
            return Invoices;
        }

        public Invoice GetInvoice(string id)
        {
            return _InvoiceDA.GetInvoice(id);
        }

        public InvoiceDetailInfo GetInvoiceDetailInformationByInvoiceId(string invoiceId)
        {
            return _InvoiceDA.GetInvoiceDetailInformationByInvoiceId(invoiceId);
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
