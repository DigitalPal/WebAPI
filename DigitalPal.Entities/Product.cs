namespace DigitalPal.Entities
{
    public class Product: BaseEntity
    {
        public float Price { get; set; }
        //public string Currency { get; set; } = "";
        public string Size { get; set; } = "";
        //public string Unit { get; set; }

        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public string HSNCode { get; set; }

    }
}
