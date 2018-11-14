using System;

namespace DigitalPal.Entities
{
    public class ProductionReport : BaseEntity
    {
        public string ProductionNumber { get; set; }
        public string ProductName { get; set; }

        public DateTime ProductionDate { get; set; }

        public string Breakage { get; set; }

        public int NoOfMouldsCasted { get; set; }
    }
}
