using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Event
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "2023-01-01", "2100-12-31", ErrorMessage = "Date is out of range")]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "2023-01-01", "2100-12-31", ErrorMessage = "Date is out of range")]
        public DateTime EndTime { get; set; } = DateTime.Now;
        public double? TicketPrice { get; set; }
        public string? TicketLink { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        public ICollection<string> Tags { get; set; } = [];
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        public IList<EventImage> Images { get; set; } = [];
        [Required]
        public string Location { get; set; }
    }
}
