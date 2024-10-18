using System.Collections.Generic;

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
        public int UserId { get; set; }

        // Add related data properties
        public Camera? Camera { get; set; } // To hold camera details
        public List<Location>? EntryLocations { get; set; } = new List<Location>(); // To hold related locations
        public List<Tag>? EntryTags { get; set; } = new List<Tag>(); // To hold related tags
    }
}
