using BitsAndBots.Data;

namespace BitsAndBots.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public ApplicationUser Author { get; set; }
        //TODO: These should be optional
        public Double? Price { get; set; }
        public Int32? Quantity { get; set; }
        //public ICollection<string> Tags { get; set; } = [];
        //public ICollection<ProductImage> Images { get; set; } = [];
        //TODO: Location
    }
}
