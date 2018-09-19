namespace DigitalPal.Entities
{
    public class Customer: BaseEntity
    {
        public string GSTNumber { get; set; } = "";
        public string ContactNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string CustomerNumber { get; set; } = "";
        public string Type { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
