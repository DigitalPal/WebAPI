using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalPal.Entities
{
    public class Dispatch: BaseEntity
    {
        public string DispatchNumber { get; set; }
        public string ChallanNumber { get; set; } = "";
        public Guid? OrderId { get; set; }
        public string OrderNumber { get; set; }

        [Required]
        public DateTime DispatchDate { get; set; }
        public string Size { get; set; }
        //public int Quantity { get; set; }
        public string TransportName { get; set; }
        public string Loading { get; set; }
        public string Unloading { get; set; }
        public float Rate { get; set; }
        public string Remark { get; set; }
        public string DispatchStatus { get; set; }
        public List<DispatchDetails> DispatchDetails { get; set; }
        public bool CanEdit { get; set; } = true;
        public bool CanDelete { get; set; } = true;
    }
}
