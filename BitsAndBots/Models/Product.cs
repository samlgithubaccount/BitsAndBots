using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace BitsAndBots.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        //TODO: These should be optional
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        //public ICollection<string> Tags { get; set; } = [];
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        public ICollection<ProductImage> Images { get; set; } = [];
        //TODO: Location
    }
}
