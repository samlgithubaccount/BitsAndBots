namespace BitsAndBots.Models
{
    public class FundraiserImage : Image
    {
        public long FundraiserId { get; set; }
        public Fundraiser Fundraiser { get; set; }
    }
}
