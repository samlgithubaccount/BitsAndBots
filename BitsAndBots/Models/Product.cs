using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public ICollection<string> Tags { get; set; } = [];
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        //TODO: Will list maintain sorting in db or do we need to change back to collection?
        public IList<ProductImage> Images { get; set; } = [];
        [Required]
        public string Location { get; set; }
    }
}
