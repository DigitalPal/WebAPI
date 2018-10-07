namespace DigitalPal.Entities
{
    public class Product: BaseEntity
    {
        public float Price { get; set; }
        public string Currency { get; set; } = "";
        public string Size { get; set; } = "";
        public string Unit { get; set; }
    }
}
