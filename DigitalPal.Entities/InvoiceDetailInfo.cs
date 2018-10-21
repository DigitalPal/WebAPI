using System;
using System.Collections.Generic;

namespace DigitalPal.Entities
{
    public class InvoiceDetailInfo : BaseEntity
    {        
        public string InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid? DispatchId { get; set; }
        public string DispatchNumber { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string Remark { get; set; }
        public float Price { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CustomerGST { get; set; }
        public string CustomerPONumber { get; set; }

        public List<DispatchDetails> Products { get; set; }
    }
}
