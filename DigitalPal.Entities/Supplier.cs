using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalPal.Entities
{
    public class Supplier: BaseEntity
    {
        public string GSTNumber { get; set; } = "";
        public string ContactNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string SupplierNumber { get; set; } = "";
        public string Type { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
