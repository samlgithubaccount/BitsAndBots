using BitsAndBots.Data;
using BitsAndBots.Validators;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public abstract class FundraiserParticipationRegistration
    {
        public long Id { get; set; }
        public long FundraiserId { get; set; }
        public Fundraiser Fundraiser { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Display(Name = "Participation Link")]
        [StringLength(60, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [UrlValidator(ErrorMessage = "{0} must be a valid URL.")]
        public string? ParticipantLink { get; set; }
    }
}
