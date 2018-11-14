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
    public class SupplierPaymentDA : DataAccessBase<SupplierPayment>, ISupplierPaymentDA
    {

        public SupplierPaymentDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_SupplierPayment;
        }

        public async Task AddSupplierPaymentAsync(SupplierPayment[] SupplierPayments)
        {
            await base.AddAsync(SupplierPayments);
        }

        public SupplierPayment[] AddSupplierPayments(SupplierPayment[] SupplierPayments)
        {
            return base.Add(SupplierPayments);
        }

        public SupplierPayment GetSupplierPayment(string id)
        {
            List<SupplierPayment> _SupplierPayment = new List<SupplierPayment>();
            var sql = String.Format("SELECT Pay.Id, Pay.[PaymentDate],Pay.[InvoiceId] AS InvoiceId, Inv.[InvoiceNumber] AS [InvoiceNumber], Pay.[SupplierId], Ord.SupplierOrderNumber, Sup.SupplierName AS [SupplierName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId], Pay.ModeOfPayment, Pay.ChequeNumber, Pay.ChequeDate  FROM {0} Pay" +
                                    " LEFT JOIN {1} Inv ON Pay.InvoiceId = Inv.Id" +
                                    " LEFT JOIN {2} Ord ON Pay.SupplierOrderId = Ord.Id" +
                                    " LEFT JOIN {3} Sup ON Ord.SupplierId = Sup.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Sup.IsActive = 1 AND Pay.Id = @id",
                                    GetTableName(), TableNameConstants.dp_Invoice, TableNameConstants.dp_SupplierOrder, TableNameConstants.dp_Supplier);

            var dynamicSupplierPayment = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierPayment), new List<string> { "Id" });

            _SupplierPayment = (Slapper.AutoMapper.MapDynamic<SupplierPayment>(dynamicSupplierPayment) as IEnumerable<SupplierPayment>).ToList();

            return _SupplierPayment.FirstOrDefault();
        }

        public Dictionary<string, SupplierPayment> GetSupplierPayments(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public SupplierPayment[] GetSupplierPayments(IEnumerable<Guid?> ids)
        {
            List<SupplierPayment> _SupplierPayment = new List<SupplierPayment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentDate],Pay.[InvoiceId] AS InvoiceId, Inv.[InvoiceNumber] AS [InvoiceNumber], Pay.[SupplierOrderId], Ord.SupplierOrderNumber AS SupplierOrderNumber, Pay.[SupplierId], Sup.SupplierName AS [SupplierName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId], Pay.ModeOfPayment, Pay.ChequeNumber, Pay.ChequeDate  FROM {0} Pay" +
                                    " LEFT JOIN {1} Inv ON Pay.InvoiceId = Inv.Id" +
                                    " LEFT JOIN {2} Ord ON Pay.SupplierOrderId = Ord.Id" +
                                    " LEFT JOIN {3} Sup ON Pay.SupplierId = Sup.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Sup.IsActive = 1 AND Pay.Id In @id",
                                    GetTableName(), TableNameConstants.dp_Invoice, TableNameConstants.dp_SupplierOrder, TableNameConstants.dp_Supplier);

            var dynamicSupplierPayment = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierPayment), new List<string> { "Id" });

            _SupplierPayment = (Slapper.AutoMapper.MapDynamic<SupplierPayment>(dynamicSupplierPayment) as IEnumerable<SupplierPayment>).ToList();

            return _SupplierPayment.ToArray();
        }

        public SupplierPayment[] GetAll()
        {
            List<SupplierPayment> _SupplierPayment = new List<SupplierPayment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentDate],Pay.[InvoiceId] AS InvoiceId, Inv.[InvoiceNumber] AS [InvoiceNumber], Pay.[SupplierOrderId], Ord.SupplierOrderNumber AS SupplierOrderNumber, Pay.[SupplierId], Sup.SupplierName AS [SupplierName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId], Pay.ModeOfPayment, Pay.ChequeNumber, Pay.ChequeDate  FROM {0} Pay" +
                                    " LEFT JOIN {1} Inv ON Pay.InvoiceId = Inv.Id" +
                                    " LEFT JOIN {2} Ord ON Pay.SupplierOrderId = Ord.Id" +
                                    " LEFT JOIN {3} Sup ON Pay.SupplierId = Sup.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Sup.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_Invoice, TableNameConstants.dp_SupplierOrder, TableNameConstants.dp_Supplier);

            var dynamicSupplierPayment = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierPayment), new List<string> { "Id" });

            _SupplierPayment = (Slapper.AutoMapper.MapDynamic<SupplierPayment>(dynamicSupplierPayment) as IEnumerable<SupplierPayment>).ToList();

            return _SupplierPayment.ToArray();
        }

        public SupplierPayment[] Search(SupplierPayment SupplierPayment)
        {
            List<SupplierPayment> _SupplierPayment = new List<SupplierPayment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentDate],Pay.[InvoiceId] AS InvoiceId, Inv.[InvoiceNumber] AS [InvoiceNumber], Pay.[SupplierOrderId], Ord.SupplierOrderNumber AS SupplierOrderNumber, Pay.[SupplierId], Sup.SupplierName AS [SupplierName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId], Pay.ModeOfPayment, Pay.ChequeNumber, Pay.ChequeDate  FROM {0} Pay" +
                                    " LEFT JOIN {1} Inv ON Pay.InvoiceId = Inv.Id" +
                                    " LEFT JOIN {2} Ord ON Pay.SupplierOrderId = Ord.Id" +
                                    " LEFT JOIN {3} Sup ON Pay.SupplierId = Sup.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Sup.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_Invoice, TableNameConstants.dp_SupplierOrder, TableNameConstants.dp_Supplier);

            var dynamicSupplierPayment = base.FindDynamic(sql, new { });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierPayment), new List<string> { "Id" });

            _SupplierPayment = (Slapper.AutoMapper.MapDynamic<SupplierPayment>(dynamicSupplierPayment) as IEnumerable<SupplierPayment>).ToList();

            return _SupplierPayment.ToArray();
        }

        public SupplierPayment[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<SupplierPayment> _SupplierPayment = new List<SupplierPayment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentDate], Pay.[InvoiceId] AS InvoiceId, Inv.[InvoiceNumber] AS [InvoiceNumber], Pay.[SupplierOrderId] AS SupplierOrderNumber, Ord.SupplierOrderNumber AS SupplierOrderNumber, Pay.[SupplierId], Sup.SupplierName AS [SupplierName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId], Pay.ModeOfPayment, Pay.ChequeNumber, Pay.ChequeDate  FROM {0} Pay" +
                                    " LEFT JOIN {1} Inv ON Pay.InvoiceId = Inv.Id" +
                                    " LEFT JOIN {2} Ord ON Pay.SupplierOrderId = Ord.Id" +
                                    " LEFT JOIN {3} Sup ON Pay.SupplierId = Sup.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Sup.IsActive = 1 AND Pay.Id In @id",
                                    GetTableName(), TableNameConstants.dp_Invoice, TableNameConstants.dp_SupplierOrder, TableNameConstants.dp_Supplier);

            var dynamicSupplierPayment = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(SupplierPayment), new List<string> { "Id" });

            _SupplierPayment = (Slapper.AutoMapper.MapDynamic<SupplierPayment>(dynamicSupplierPayment) as IEnumerable<SupplierPayment>).ToList();

            return _SupplierPayment.ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new SupplierPayment()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(SupplierPayment item)
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
                item.SupplierId,
                item.SupplierOrderId,
                item.InvoiceId,
                item.PaymentDate,
                item.PaymentStatus,
                item.PlantId,
                item.ModeOfPayment,
                item.ChequeDate,
                item.ChequeNumber
            };
        }

        public SupplierPayment[] UpdateSupplierPayments(SupplierPayment[] SupplierPayments)
        {
            if (SupplierPayments.Any())
            {
                base.Update(SupplierPayments);
            }

            return SupplierPayments;
        }

        public SupplierPayment[] DeleteSupplierPayments(string id)
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
