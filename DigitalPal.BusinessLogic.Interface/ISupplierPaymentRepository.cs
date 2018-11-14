using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface ISupplierPaymentRepository
    {
        Task AddSupplierPaymentAsync(SupplierPayment[] SupplierPayments);
        SupplierPayment[] AddSupplierPayments(SupplierPayment[] SupplierPayments);
        SupplierPayment[] Search(SupplierPayment SupplierPayment);
        SupplierPayment GetSupplierPayment(string id);

        Dictionary<string, SupplierPayment> GetSupplierPayments(string[] ids);

        SupplierPayment[] GetSupplierPayments(IEnumerable<Guid?> ids);

        SupplierPayment[] GetAll();

        SupplierPayment[] GetByIds(IEnumerable<Guid> Ids);

        SupplierPayment[] UpdateSupplierPayments(SupplierPayment[] SupplierPayments);

        SupplierPayment[] DeleteSupplierPayments(string id);
    }
}
