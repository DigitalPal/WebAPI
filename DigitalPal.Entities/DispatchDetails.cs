using System;

namespace DigitalPal.Entities
{
    public class DispatchDetails: BaseEntity
    {
        public DateTime DispatchDate { get; set; }
        public Guid CustomerId { get; set; }
        public string PONumber { get; set; } = "";
        public string ChallanNumber { get; set; } = "";
        public string Size { get; set; } = "";
        public int Quantity { get; set; }
        public string TransportName { get; set; } = "";
        public string Loading { get; set; } = "";
        public string Unloading { get; set; } = "";
        public int Rate { get; set; }
        public string Remark { get; set; } = "";
    }
}
