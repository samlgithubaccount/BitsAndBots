namespace BitsAndBots.Models
{
    public class ProductImage
    {
        public long Id { get; set; }
        public string? AltText { get; set; }
        public byte[] ImageData { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        //TODO: Sequence number
    }
}
