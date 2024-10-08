using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class ProductEnquiry
    {
        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Message { get; set; }
        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
