using BitsAndBots.Data;
using BitsAndBots.Validators;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class Fundraiser
    {
        public long Id { get; set; }
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Required]
        public string Title { get; set; }
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
        [Required]
        public string Description { get; set; }
        [Required]
        [FutureDateTimeValidator(ErrorMessage = "Start must be in the future.")]
        public DateTime StartTime { get; set; } = DateTime.Now.AddHours(1);
        [Required]
        [FutureDateTimeValidator(ErrorMessage = "Ends must be in the future.")]
        [EndTimeValidator("StartTime")]
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(2);
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Required]
        public string Organiser { get; set; }
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        public string? FundraiserLink { get; set; }
        public bool SupportsParticipantLinks { get; set; }
        public bool SupportsTeamRegistration { get; set; }
        public bool SupportsIndividualRegistration { get; set; }
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Atleast one registration type must be selected.")]
        public bool RegistrationTypeSelected { get { return SupportsIndividualRegistration || SupportsTeamRegistration; } set { } }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdatedTimestamp { get; set; }
        public string CreatedUserId { get; set; }
        public ApplicationUser CreatedUser { get; set; }
        //TODO: Enable search by tags
        public ICollection<string> Tags { get; set; } = [];
        [MinLength(1, ErrorMessage = "A minimum of 1 Image is required.")]
        public IList<FundraiserImage> Images { get; set; } = [];
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required]
        public string? Location { get; set; }
        public ICollection<IndividualFundraiserParticipationRegistration> IndividualFundraiserRegistrations { get; set; } = [];
        public ICollection<TeamFundraiserParticipationRegistration> TeamFundraiserRegistrations { get; set; } = [];
    }
}
