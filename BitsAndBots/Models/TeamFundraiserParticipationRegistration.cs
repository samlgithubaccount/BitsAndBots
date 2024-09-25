using BitsAndBots.Data;
using System.ComponentModel.DataAnnotations;

namespace BitsAndBots.Models
{
    public class TeamFundraiserParticipationRegistration : FundraiserParticipationRegistration
    {
        [Required]
        public string TeamName { get; set; }
        public ICollection<ApplicationUser> TeamMembers { get; set; } = [];
    }
}
