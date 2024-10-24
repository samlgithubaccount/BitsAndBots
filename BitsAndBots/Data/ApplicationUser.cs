using BitsAndBots.Models;
using Microsoft.AspNetCore.Identity;

namespace BitsAndBots.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Product> Products { get; set; } = [];
        public ICollection<Event> Events { get; set; } = [];
        public ICollection<Fundraiser> Fundraisers { get; set; } = [];
        public ICollection<IndividualFundraiserParticipationRegistration> IndividualFundraiserRegistrations { get; set; } = [];
        public ICollection<TeamFundraiserParticipationRegistration> TeamFundraiserRegistrations { get; set; } = [];
        public ICollection<TeamFundraiserParticipationRegistration> FundraiserRegistrationTeamMemberships { get; set; } = [];
    }

}
