using BitsAndBots.Data;
using BitsAndBots.Validators;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Event
    {
        public long Id { get; set; }
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Required]
        public string Title { get; set; }
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Start time")]
        [FutureDateTimeValidator("ExistingStartTime")]
        public DateTime StartTime { get; set; } = DateTime.Now.AddHours(1);
        public DateTime ExistingStartTime { get; set; }
        [Required]
        [Display(Name = "End time")]
        [FutureDateTimeValidator("ExistingEndTime")]
        [EndTimeValidator("StartTime")]
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(2);
        public DateTime ExistingEndTime { get; set; }
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Required]
        public string Organiser { get; set; }
        [Display(Name = "Ticket Price")]
        [Range(0, 999999999D)]
        public double? TicketPrice { get; set; }
        [Display(Name = "Ticket Link")]
        [StringLength(60, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [UrlValidator(ErrorMessage = "{0} must be a valid URL.")]
        public string? TicketLink { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        [StringLength(150, ErrorMessage = "{0} may only contain up to {1} characters.")]
        public string? Tags { get; set; }
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        public IList<EventImage> Images { get; set; } = [];
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required]
        public string Location { get; set; }
    }
}
