namespace DigitalPal.Entities
{
    public class PriceDetails: BaseEntity
    {
        public int Price { get; set; }
        public string Currency { get; set; } = "";
        public string Size { get; set; } = "";
        public string Unit { get; set; }
    }
}
