using System;

namespace DigitalPal.Entities
{
    public class RawMaterialConsumption: BaseEntity
    {
        public DateTime ConsumptionDate { get; set; }
        public Guid RawMaterialId { get; set; }
        public int NoOfMouldsCasted { get; set; }
        public int Quantity { get; set; }
        public string Remark { get; set; } = "";
    }
}
