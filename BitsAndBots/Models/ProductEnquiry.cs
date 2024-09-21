using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class ProductEnquiry
    {
        [Required]
        public string Message { get; set; }
        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
    }
}
