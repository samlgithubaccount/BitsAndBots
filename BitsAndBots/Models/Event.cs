using BitsAndBots.Data;
using BitsAndBots.Validators;
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
        [Required]
        [FutureDateTime(ErrorMessage = "Start must be in the future.")]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [Required]
        [FutureDateTime(ErrorMessage = "End must be in the future.")]
        [EndTimeValidator("StartTime")]
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(1);
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
