using System;

namespace DigitalPal.Entities
{
    public class Plant: BaseEntity
    {
        public string Logo { get; set; } = "";
        public string Address { get; set; } = "";
        public string ContactNumber{ get; set; } = "";
        public Guid AdminUser { get; set; }
    }
}
