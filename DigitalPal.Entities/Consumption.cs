using System;

namespace DigitalPal.Entities
{
    public class Consumption: BaseEntity
    {
        public Guid? RawMaterialId { get; set; }

        public string RawMaterial { get; set; }

        public DateTime ConsumptionDate { get; set; }

        public float Quantity { get; set; }

        public string Remark { get; set; }
    }
}
