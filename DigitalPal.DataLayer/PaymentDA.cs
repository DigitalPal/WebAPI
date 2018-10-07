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
            return FindById(Guid.Parse(id));
        }

        public Dictionary<string, Payment> GetPayments(string[] ids)
        {
            var result = Find(x => ids.Any(e => e == x.Id.ToString()));
            return result.ToDictionary(x => x.Id.ToString(), y => y);
        }

        public Payment[] GetPayments(IEnumerable<Guid?> ids)
        {
            var sql = String.Format("SELECT * FROM {0} WHERE Id IN @ids AND IsActive = 1", GetTableName());
            return base.Find(sql, new { ids }).ToArray();
        }

        public Payment[] GetAll()
        {
            return base.FindAll().ToArray();
        }

        public Payment[] GetByIds(IEnumerable<Guid> Ids)
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
                item.InvoiceId,
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
