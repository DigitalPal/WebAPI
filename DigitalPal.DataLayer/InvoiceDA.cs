using DigitalPal.DataAccess.Interface;
using DigitalPal.DataAccess.Util;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess
{
    public class InvoiceDA : DataAccessBase<Invoice>, IInvoiceDA
    {

        public InvoiceDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Invoice;
        }

        public async Task AddInvoiceAsync(Invoice[] Invoices)
        {
            await base.AddAsync(Invoices);
        }

        public Invoice[] AddInvoices(Invoice[] Invoices)
        {
            return base.Add(Invoices);
        }

        public Invoice GetInvoice(string id)
        {
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Invoice> GetInvoices(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Invoice[] GetInvoices(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Invoice[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Invoice[] GetByIds(IEnumerable<Guid> Ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN ( @Ids ) AND IsActive = 1", GetTableName());
            return base.FindByTempTableIds(sql, Ids).ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Invoice()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Invoice item)
        {
            return new
            {
                item.Id,
                item.CreatedOn,
                item.ModifiedOn,
                item.IsActive,
                item.CreatedBy,
                item.ModifiedBy,
                item.TenantId,
                item.Amount,
                item.DispatchId,
                item.InvoiceDate,
                item.InvoiceNumber,
                item.InvoiceStatus,
                item.LaodingUnloadingCharges,
                item.OrderId,
                item.TransportCharges
            };
        }

        public Invoice[] UpdateInvoices(Invoice[] Invoices)
        {
            if (Invoices.Any())
            {
                base.Update(Invoices);
            }

            return Invoices;
        }

        public Invoice[] DeleteInvoices(string id)
        {
            if (id != null)
            {
                string[] ids = { id };
                base.DeleteByDbId(ids);
            }

            return null;
        }
    }
}
