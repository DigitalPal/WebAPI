using System;

namespace DigitalPal.Entities
{
    public class RawMaterialInward: BaseEntity
    {
        public DateTime InwardDate { get; set; }
        public Guid RawMaterialId { get; set; }
        public string RawMaterial { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string VechicalNumber { get; set; }
        public string ChallanNumber { get; set; } = "";
        public int Quantity { get; set; }
        public string UnloadingDetails { get; set; } = "";
        public string Remark { get; set; } = "";
    }
}
