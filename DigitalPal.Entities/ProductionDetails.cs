using System;

namespace DigitalPal.Entities
{
    public class ProductionDetails: BaseEntity
    {
        public DateTime ProductionDate { get; set; }
        public string Breakage { get; set; } = "";
        public int NoOfMouldsCasted { get; set; }
        public string Size { get; set; } = "";
        public int Quantity { get; set; }
        public string Remark { get; set; } = "";
    }
}
