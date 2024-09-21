namespace BitsAndBots.Models
{
    public class EventImage : Image
    {
        public long EventId { get; set; }
        public Event Event { get; set; }
    }
}
