using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IPaymentRepository
    {
        Task AddPaymentAsync(Payment[] Payments);
        Payment[] AddPayments(Payment[] Payments);

        Payment GetPayment(string id);

        Dictionary<string, Payment> GetPayments(string[] ids);

        Payment[] GetPayments(IEnumerable<Guid?> ids);

        Payment[] GetAll();

        Payment[] GetByIds(IEnumerable<Guid> Ids);

        Payment[] UpdatePayments(Payment[] Payments);

        Payment[] DeletePayments(string id);
    }
}
