using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IPaymentDA
    {
        Task AddPaymentAsync(Payment[] Payments);
        Payment[] AddPayments(Payment[] Payments);
        Payment[] Search(Payment Payment);
        Payment GetPayment(string id);

        Dictionary<string, Payment> GetPayments(string[] ids);

        Payment[] GetPayments(IEnumerable<Guid?> ids);

        Payment[] GetAll();

        Payment[] GetByIds(IEnumerable<Guid> Ids);

        Payment[] UpdatePayments(Payment[] Payments);

        Payment[] DeletePayments(string id);
    }
}
