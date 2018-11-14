using System;
using static DigitalPal.Common.Enum;

namespace DigitalPal.Entities
{
    public class SupplierPayment: BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public string InvoiceNumber { get; set; }
        public Guid? InvoiceId { get; set; }
        public string SupplierOrderNumber { get; set; }
        public Guid? SupplierOrderId { get; set; }
        public string SupplierName { get; set; }
        public Guid? SupplierId { get; set; }
        public float Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string ModeOfPayment { get; set; }
        public string ChequeNumber { get; set; } = "";
        public DateTime? ChequeDate { get; set; }
    }
}
