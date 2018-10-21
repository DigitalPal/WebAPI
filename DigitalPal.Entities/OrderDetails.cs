using System;

namespace DigitalPal.Entities
{
    public class OrderDetails : BaseEntity
    {
        public Guid? OrderId { get; set; }

        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
