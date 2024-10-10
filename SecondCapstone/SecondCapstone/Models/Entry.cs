namespace SecondCapstone.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string CaptureDate { get; set; }
        public string FileSize { get; set; }
        public string Resolution { get; set; }
        public string PhysicalBackUps { get; set; }

        public int CameraId { get; set; }
        public Camera Camera { get; set; }

        public int UserId { get; set; }
        public UserProfile User { get; set; }

        // Navigation properties for related entities
        public List<EntryTag> EntryTags { get; set; }
        public List<EntryLocation> EntryLocations { get; set; }
    }
}
