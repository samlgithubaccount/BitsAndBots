using BitsAndBots.Data;

namespace BitsAndBots.Models
{
    public class FundraiserParticipantionRegistration
    {
        public long Id { get; set; }
        public long FundraiserId { get; set; }
        public Fundraiser Fundraiser { get; set; }
        //TODO: Allow user to add message about their participation
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string? ParticipantLink { get; set; }
    }
}
