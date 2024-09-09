namespace BitsAndBots.Configuration
{
    public class FileUploadConstraints
    {
        public long MaxFileSize { get; set; } = 2 * 1024 * 1024; // 2MB
        public string AllowedExtensions { get; set; } = ".jpg,";
        public int MaxFiles { get; set; } = 10;
    }
}
