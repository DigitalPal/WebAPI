using System;
using System.Collections.Generic;

namespace DigitalPal.Entities
{
    public class Order: BaseEntity
    {
        public string OrderNumber { get; set; }
        public string CustomerPONumber { get; set; } = "";
        public string CustomerName { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public string Remark { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderDetails> Products { get; set; }
    }
}
