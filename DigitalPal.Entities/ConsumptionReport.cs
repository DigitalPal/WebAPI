using System;

namespace DigitalPal.Entities
{
    public class ConsumptionReport : BaseEntity
    {
        public DateTime ConsumptionDate { get; set; }

        public string RawMaterial { get; set; }

        public float Quantity { get; set; }

        public string MeasureType { get; set; }
    }
}
