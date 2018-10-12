using System;
using static DigitalPal.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace DigitalPal.Entities
{
    public class Invoice: BaseEntity
    {
        [StringLength(50)]
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        public Guid? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public Guid? DispatchId { get; set; }
        public string DispatchNumber { get; set; }
        public float TransportCharges { get; set; }
        public float LoadingCharges { get; set; }
        public float UnloadingCharges { get; set; }
        public string Remark { get; set; }
        public float Amount { get; set; }
        public Status InvoiceStatus { get; set; }
    }
}
