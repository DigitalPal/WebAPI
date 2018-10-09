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
            List<Invoice> _Invoice = new List<Invoice>();
            var sql = String.Format("select Inv.[Id], Inv.[InvoiceNumber], Inv.[InvoiceDate], Inv.[OrderId], Ord.OrderNumber as OrderNumber, Inv.[DispatchId], Dispatch.DispatchNumber as DispatchNumber ,Inv.[TransportCharges], Inv.[LoadingUnloadingCharges], Inv.[Amount], Inv.[InvoiceStatus], Inv.[CreatedOn], Inv.[CreatedBy], Inv.[ModifiedOn], Inv.[ModifiedBy], Inv.[IsActive], Inv.[TenantId], Inv.[PlantId]" +
                                    " from [dbo].[dp_Invoice] Inv" +
                                    " inner join [dbo].[dp_Order] Ord on Inv.OrderId = Ord.Id" +
                                    " inner join [dbo].[dp_Dispatch] Dispatch  on Inv.DispatchId = Dispatch.Id"+
                                    " Where dispatch.IsActive = 1 and Ord.IsActive = 1 and Inv.IsActive = 1  and ord.Id = @id",
                                    GetTableName(), TableNameConstants.dp_Order, TableNameConstants.dp_Dispatch);

            var dynamicInvoice = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Invoice), new List<string> { "Id" });
           
            _Invoice = (Slapper.AutoMapper.MapDynamic<Invoice>(dynamicInvoice) as IEnumerable<Invoice>).ToList();
            
            return _Invoice.FirstOrDefault();
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
                item.InvoiceId,
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
