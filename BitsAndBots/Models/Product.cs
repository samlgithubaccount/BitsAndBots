using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        //TODO: These should be optional
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        //public ICollection<string> Tags { get; set; } = [];
        //public ICollection<ProductImage> Images { get; set; } = [];
        //TODO: Location
    }
}
