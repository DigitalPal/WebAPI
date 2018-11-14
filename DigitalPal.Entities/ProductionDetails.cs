using System;

namespace DigitalPal.Entities
{
    public class ProductionDetails: BaseEntity
    {
        public Guid? ProductionId { get; set; }

        public Guid? ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int Breakage { get; set; }
    }
}
