using System;
using static DigitalPal.Common.Enum;

namespace DigitalPal.Entities
{
    public class Invoice: BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid? DispatchId { get; set; }
        public string DispatchNumber { get; set; }
        public float TransportCharges { get; set; }
        public float LaodingUnloadingCharges { get; set; }
        public float Amount { get; set; }
        public Status InvoiceStatus { get; set; }
    }
}
