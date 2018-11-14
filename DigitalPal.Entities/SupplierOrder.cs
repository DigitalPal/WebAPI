using System;
using System.Collections.Generic;

namespace DigitalPal.Entities
{
    public class SupplierOrder : BaseEntity
    {
        public string SupplierOrderNumber { get; set; }
        public string SupplierPONumber { get; set; } = "";
        public string SupplierName { get; set; }
        public Guid? SupplierId { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public float Price { get; set; }
        public string Remark { get; set; }
        public string OrderStatus { get; set; }
        public List<SupplierOrderDetails> RawMaterial { get; set; }
    }

    public class SupplierOrderReport : BaseEntity
    {
        public string SupplierOrderNumber { get; set; }
        public string SupplierName { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public int Quantity { get; set; }
        public string RawMaterialName { get; set; }
        public string OrderStatus { get; set; }
    }
}
