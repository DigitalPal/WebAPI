using System;

namespace DigitalPal.Entities
{
    public class SupplierOrderDetails : BaseEntity
    {
        public Guid? SupplierOrderId { get; set; }
        public string MeasureType { get; set; }
        public Guid? RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
