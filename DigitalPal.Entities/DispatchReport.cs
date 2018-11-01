using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalPal.Entities
{
    public class DispatchReport: BaseEntity
    {
        public string ChallanNumber { get; set; } = "";
        public string OrderNumber { get; set; }
        [Required]
        public DateTime DispatchDate { get; set; }
        public int DispatchQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public string TransportName { get; set; }
        public string Loading { get; set; }
        public string Unloading { get; set; }
        public string ProductName { get; set; } = "";
        public string CustomerName { get; set; } = "";
    }
}
