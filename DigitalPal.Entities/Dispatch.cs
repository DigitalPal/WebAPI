﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DigitalPal.Common.Enum;

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
        public Status DispatchStatus { get; set; }
        public List<DispatchDetails> DispatchDetails { get; set; }
    }
}