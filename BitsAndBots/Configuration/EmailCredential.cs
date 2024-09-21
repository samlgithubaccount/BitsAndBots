namespace BitsAndBots.Configuration
{
    public class EmailCredential
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
    }
}
