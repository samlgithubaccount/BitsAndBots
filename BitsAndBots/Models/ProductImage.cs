namespace BitsAndBots.Models
{
    public class ProductImage : Image
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
