using System;
using static DigitalPal.Common.Enum;

namespace DigitalPal.Entities
{
    public class Payment: BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public string InvoiceNumber { get; set; }
        public Guid? InvoiceId { get; set; }
        public string OrderNumber { get; set; }
        public Guid? OrderId { get; set; }
        public string CustomerName { get; set; }
        public Guid? CustomerId { get; set; }
        public float Amount { get; set; }
        public Status PaymentStatus { get; set; }
    }
}
