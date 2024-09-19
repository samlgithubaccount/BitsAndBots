namespace BitsAndBots.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string? AltText { get; set; }
        public byte[] ImageData { get; set; }
    }
}
