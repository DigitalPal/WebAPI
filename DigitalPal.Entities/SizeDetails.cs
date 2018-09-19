namespace DigitalPal.Entities
{
    public class SizeDetails: BaseEntity
    {
        public string Size { get; set; }
        public string ConversionFactor { get; set; } = "";
    }
}
