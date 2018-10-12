using System;

namespace DigitalPal.Entities
{
    public class DispatchDetails: BaseEntity
    {
        public Guid? DispatchId { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; } = "";
    }
}
