using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class TeamFundraiserParticipationRegistration : FundraiserParticipationRegistration
    {
        [Display(Name = "Team Name")]
        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string TeamName { get; set; }
        public ICollection<ApplicationUser> TeamMembers { get; set; } = [];
    }
}
