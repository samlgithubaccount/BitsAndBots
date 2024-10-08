using BitsAndBots.Data;

namespace BitsAndBots.Models
{
    public abstract class FundraiserParticipationRegistration
    {
        public long Id { get; set; }
        public long FundraiserId { get; set; }
        public Fundraiser Fundraiser { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string? ParticipantLink { get; set; }
    }
}
