namespace Domain.Entities
{
    public class AudioFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public Skill? Skill { get; set; }
        public ContentBlock? ContentBlock { get; set; }
    }
}
