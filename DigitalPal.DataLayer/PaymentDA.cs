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
    public class PaymentDA : DataAccessBase<Payment>, IPaymentDA
    {

        public PaymentDA(ISqlDatabaseSettings sqlDataBaseSettings) : base(sqlDataBaseSettings)
        {
        }

        internal override string GetTableName()
        {
            return TableNameConstants.dp_Payment;
        }

        public async Task AddPaymentAsync(Payment[] Payments)
        {
            await base.AddAsync(Payments);
        }

        public Payment[] AddPayments(Payment[] Payments)
        {
            return base.Add(Payments);
        }

        public Payment GetPayment(string id)
        {
            List<Payment> _Payment = new List<Payment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentId], Inv.PaymentNumber AS PaymentNumber ,Pay.[PaymentDate], Pay.[OrderId], Ord.OrderNumber AS OrderNumber, Pay.[CustomerId], Cust.Name AS [CustomerName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId] FROM {0} Pay" +
                                    " INNER JOIN {1} Inv ON Pay.PaymentId = Inv.Id" +
                                    " INNER JOIN {2} Ord ON Pay.OrderId = Ord.Id" +
                                    " INNER JOIN {3} Cust ON Pay.CustomerId = Cust.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Cust.IsActive = 1 AND Pay.Id = @id",
                                    GetTableName(), TableNameConstants.dp_Payment, TableNameConstants.dp_Order, TableNameConstants.dp_Customer);

            var dynamicPayment = base.FindDynamic(sql, new { id });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Payment), new List<string> { "Id" });

            _Payment = (Slapper.AutoMapper.MapDynamic<Payment>(dynamicPayment) as IEnumerable<Payment>).ToList();

            return _Payment.FirstOrDefault();
        }

        public Dictionary<string, Payment> GetPayments(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Payment[] GetPayments(IEnumerable<Guid?> ids)
        {
            List<Payment> _Payment = new List<Payment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentId], Inv.PaymentNumber AS PaymentNumber ,Pay.[PaymentDate], Pay.[OrderId], Ord.OrderNumber AS OrderNumber, Pay.[CustomerId], Cust.Name AS [CustomerName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId] FROM {0} Pay" +
                                    " INNER JOIN {1} Inv ON Pay.PaymentId = Inv.Id" +
                                    " INNER JOIN {2} Ord ON Pay.OrderId = Ord.Id" +
                                    " INNER JOIN {3} Cust ON Pay.CustomerId = Cust.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Cust.IsActive = 1 AND Pay.Id In @id",
                                    GetTableName(), TableNameConstants.dp_Payment, TableNameConstants.dp_Order, TableNameConstants.dp_Customer);

            var dynamicPayment = base.FindDynamic(sql, new { ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Payment), new List<string> { "Id" });

            _Payment = (Slapper.AutoMapper.MapDynamic<Payment>(dynamicPayment) as IEnumerable<Payment>).ToList();

            return _Payment.ToArray();
        }

        public Payment[] GetAll()
        {
            List<Payment> _Payment = new List<Payment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentId], Inv.PaymentNumber AS PaymentNumber ,Pay.[PaymentDate], Pay.[OrderId], Ord.OrderNumber AS OrderNumber, Pay.[CustomerId], Cust.Name AS [CustomerName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId] FROM {0} Pay" +
                                    " INNER JOIN {1} Inv ON Pay.PaymentId = Inv.Id" +
                                    " INNER JOIN {2} Ord ON Pay.OrderId = Ord.Id" +
                                    " INNER JOIN {3} Cust ON Pay.CustomerId = Cust.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Cust.IsActive = 1",
                                    GetTableName(), TableNameConstants.dp_Payment, TableNameConstants.dp_Order, TableNameConstants.dp_Customer);

            var dynamicPayment = base.FindDynamic(sql, new {  });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Payment), new List<string> { "Id" });

            _Payment = (Slapper.AutoMapper.MapDynamic<Payment>(dynamicPayment) as IEnumerable<Payment>).ToList();

            return _Payment.ToArray();
        }

        public Payment[] GetByIds(IEnumerable<Guid> Ids)
        {
            List<Payment> _Payment = new List<Payment>();
            var sql = String.Format("SELECT Pay.[Id], Pay.[PaymentId], Inv.PaymentNumber AS PaymentNumber ,Pay.[PaymentDate], Pay.[OrderId], Ord.OrderNumber AS OrderNumber, Pay.[CustomerId], Cust.Name AS [CustomerName], Pay.[Amount], Pay.[PaymentStatus], Pay.[CreatedOn], Pay.[CreatedBy], Pay.[ModifiedOn], Pay.[ModifiedBy], Pay.[IsActive], Pay.[TenantId], Pay.[PlantId] FROM {0} Pay" +
                                    " INNER JOIN {1} Inv ON Pay.PaymentId = Inv.Id" +
                                    " INNER JOIN {2} Ord ON Pay.OrderId = Ord.Id" +
                                    " INNER JOIN {3} Cust ON Pay.CustomerId = Cust.Id" +
                                    " WHERE Pay.IsActive = 1 AND Inv.IsActive = 1 AND Ord.IsActive = 1 AND Cust.IsActive = 1 AND Pay.Id In @id",
                                    GetTableName(), TableNameConstants.dp_Payment, TableNameConstants.dp_Order, TableNameConstants.dp_Customer);

            var dynamicPayment = base.FindDynamic(sql, new { Ids });

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Payment), new List<string> { "Id" });

            _Payment = (Slapper.AutoMapper.MapDynamic<Payment>(dynamicPayment) as IEnumerable<Payment>).ToList();

            return _Payment.ToArray();
        }

        public string GetEntityName()
        {
            return GetTableName();
        }

        public string[] GetColumns()
        {
            PropertyInfo[] props = Mapping(new Payment()).GetType().GetProperties();
            return props.Select(x => x.Name).ToArray();
        }

        internal override dynamic Mapping(Payment item)
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
                item.CustomerId,
                item.OrderId,
                item.PaymentDate,
                item.PaymentStatus,
                item.PlantId
            };
        }

        public Payment[] UpdatePayments(Payment[] Payments)
        {
            if (Payments.Any())
            {
                base.Update(Payments);
            }

            return Payments;
        }

        public Payment[] DeletePayments(string id)
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
