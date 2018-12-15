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

        public InvoiceDetailInfo GetInvoiceDetailInformationByInvoiceId(string invoiceId)
        {
            List<InvoiceDetailInfo> _InvoiceDetailInfo = new List<InvoiceDetailInfo>();
            var sql = String.Format("SELECT Inv.Id AS Id, Ord.[CustomerId], Cust.[Name] AS [CustomerName], Cust.[Address] AS [Address], Cust.[GSTNumber] AS [CustomerGST], Ord.[CustomerPONumber], Inv.[InvoiceNumber] AS [InvoiceNumber], " +
                                    " Dispatch.[DispatchDate], Dispatch.[Id] AS DispatchId, Dispatch.[DispatchNumber], DispatchDetails.[Quantity] AS Products_Quantity, Dispatch.[Remark]," +
                                    " Ord.[Id] AS OrderId, Ord.[OrderNumber], Ord.[OrderDate], Inv.[Amount] AS Price, Inv.[TransportCharges] AS TransportCharges, Inv.[LoadingCharges] AS LoadingCharges, Inv.[UnloadingCharges] AS UnloadingCharges, DispatchDetails.ProductId AS Products_ProductId, Prod.[Name] AS Products_ProductName, Prod.[Size] AS Products_Size, Prod.[Height] AS Products_Height , Prod.[Width] AS Products_Width , Prod.[Length] AS Products_Length, Prod.[HSNCode] AS Products_HSNCode , Inv.TenantId, Inv.PlantId, Inv.IsActive FROM {0} Inv" +
                                    " LEFT JOIN {1} Ord ON Inv.OrderId = Ord.Id" +
                                    " LEFT JOIN {2} Dispatch  ON Inv.DispatchId = Dispatch.Id" +
                                    " LEFT JOIN {3} DispatchDetails ON DispatchDetails.DispatchId = Dispatch.Id" +
                                    " LEFT JOIN {4} Prod ON Prod.Id = DispatchDetails.ProductId" +
                                    " LEFT JOIN {5} Cust ON Cust.Id = Ord.CustomerId" +
                                    " WHERE Ord.IsActive = 1 AND Prod.IsActive = 1 AND Cust.IsActive = 1 AND Dispatch.IsActive = 1 AND Inv.IsActive = 1 AND Inv.[Id] = '{6}'",
            TableNameConstants.dp_Invoice, TableNameConstants.dp_Order, TableNameConstants.dp_Dispatch, TableNameConstants.dp_DispatchDetails, TableNameConstants.dp_Product, TableNameConstants.dp_Customer, invoiceId);

            var dynamicOrder = base.FindDynamic(sql, new {  });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(InvoiceDetailInfo), new List<string> { "Id" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(DispatchDetails), new List<string> { "ProductId" });
            _InvoiceDetailInfo = (Slapper.AutoMapper.MapDynamic<InvoiceDetailInfo>(dynamicOrder) as IEnumerable<InvoiceDetailInfo>).ToList();
            return _InvoiceDetailInfo.FirstOrDefault();
        }

        public Invoice GetInvoice(string id)
        {
            List<Invoice> _Invoice = new List<Invoice>();
            var sql = String.Format("select Inv.[Id],Inv.[CanEdit],Inv.[CanDelete], Inv.[InvoiceNumber], Inv.[InvoiceDate], Inv.[OrderId], Ord.OrderNumber as OrderNumber, Inv.[DispatchId], Dispatch.DispatchNumber as DispatchNumber ,Inv.[TransportCharges], Inv.[LoadingCharges],Inv.[UnloadingCharges], Inv.[Amount], Inv.[InvoiceStatus], Inv.[CreatedOn], Inv.[CreatedBy], Inv.[ModifiedOn], Inv.[ModifiedBy], Inv.[IsActive], Inv.[TenantId], Inv.[PlantId], Inv.[Remark]" +
                                    " from {0} Inv" +
                                    " inner join {1} Ord on Inv.OrderId = Ord.Id" +
                                    " inner join {2} Dispatch  on Inv.DispatchId = Dispatch.Id"+
                                    " Where dispatch.IsActive = 1 and Ord.IsActive = 1 and Inv.IsActive = 1  and Inv.Id = @id",
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
            List<Invoice> _Invoice = new List<Invoice>();
            var sql = String.Format("select Inv.[Id],Inv.[CanEdit],Inv.[CanDelete], Inv.[InvoiceNumber], Inv.[InvoiceDate], Inv.[OrderId], Ord.OrderNumber as OrderNumber, Inv.[DispatchId], Dispatch.DispatchNumber as DispatchNumber ,Inv.[TransportCharges], Inv.[LoadingCharges],Inv.[UnloadingCharges], Inv.[Amount], Inv.[InvoiceStatus], Inv.[CreatedOn], Inv.[CreatedBy], Inv.[ModifiedOn], Inv.[ModifiedBy], Inv.[IsActive], Inv.[TenantId], Inv.[PlantId]" +
                                    " from {0} Inv" +
                                    " inner join {1} Ord on Inv.OrderId = Ord.Id" +
                                    " inner join {2} Dispatch  on Inv.DispatchId = Dispatch.Id" +
                                    " Where dispatch.IsActive = 1 and Ord.IsActive = 1 and Inv.IsActive = 1  and Inv.Id IN @id",
                                    GetTableName(), TableNameConstants.dp_Order, TableNameConstants.dp_Dispatch);

            var dynamicInvoice = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Invoice), new List<string> { "Id" });

            _Invoice = (Slapper.AutoMapper.MapDynamic<Invoice>(dynamicInvoice) as IEnumerable<Invoice>).ToList();

            return _Invoice.ToArray();
        }

        public Invoice[] GetAll()
        {
            List<Invoice> _Invoice = new List<Invoice>();
            var sql = String.Format("select Inv.[Id],Inv.[CanEdit],Inv.[CanDelete], Inv.[InvoiceNumber], Inv.[InvoiceDate], Inv.[OrderId], Ord.OrderNumber as OrderNumber, Inv.[DispatchId], Dispatch.DispatchNumber as DispatchNumber ,Inv.[TransportCharges], Inv.[LoadingCharges],Inv.[UnloadingCharges], Inv.[Amount], Inv.[InvoiceStatus], Inv.[CreatedOn], Inv.[CreatedBy], Inv.[ModifiedOn], Inv.[ModifiedBy], Inv.[IsActive], Inv.[TenantId], Inv.[PlantId]" +
                                    " from {0} Inv" +
                                    " inner join {1} Ord on Inv.OrderId = Ord.Id" +
                                    " inner join {2} Dispatch  on Inv.DispatchId = Dispatch.Id" +
                                    " Where dispatch.IsActive = 1 and Ord.IsActive = 1 and Inv.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_Order, TableNameConstants.dp_Dispatch);

            var dynamicInvoice = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Invoice), new List<string> { "Id" });

            _Invoice = (Slapper.AutoMapper.MapDynamic<Invoice>(dynamicInvoice) as IEnumerable<Invoice>).ToList();

            return _Invoice.ToArray();
        }

        public Invoice[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<Invoice> _Invoice = new List<Invoice>();
            var sql = String.Format("select Inv.[Id],Inv.[CanEdit],Inv.[CanDelete], Inv.[InvoiceNumber], Inv.[InvoiceDate], Inv.[OrderId], Ord.OrderNumber as OrderNumber, Inv.[DispatchId], Dispatch.DispatchNumber as DispatchNumber ,Inv.[TransportCharges], Inv.[LoadingCharges],Inv.[UnloadingCharges], Inv.[Amount], Inv.[InvoiceStatus], Inv.[CreatedOn], Inv.[CreatedBy], Inv.[ModifiedOn], Inv.[ModifiedBy], Inv.[IsActive], Inv.[TenantId], Inv.[PlantId]" +
                                    " from {0} Inv" +
                                    " inner join {1} Ord on Inv.OrderId = Ord.Id" +
                                    " inner join {2} Dispatch  on Inv.DispatchId = Dispatch.Id" +
                                    " Where dispatch.IsActive = 1 and Ord.IsActive = 1 and Inv.IsActive = 1  and Inv.Id IN @id",
                                    GetTableName(), TableNameConstants.dp_Order, TableNameConstants.dp_Dispatch);

            var dynamicInvoice = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Invoice), new List<string> { "Id" });

            _Invoice = (Slapper.AutoMapper.MapDynamic<Invoice>(dynamicInvoice) as IEnumerable<Invoice>).ToList();

            return _Invoice.ToArray();
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
                item.PlantId,
                item.Amount,
                item.DispatchId,
                item.OrderId,
                item.InvoiceDate,
                item.InvoiceNumber,
                item.InvoiceStatus,
                item.LoadingCharges,
                item.UnloadingCharges,
                item.Remark,
                item.TransportCharges,
                item.CanEdit,
                item.CanDelete
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
