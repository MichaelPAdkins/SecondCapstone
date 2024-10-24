using System.Collections.Generic;

namespace SecondCapstone.Models
{
    public class Entry
    {
    public int Id { get; set; }
    public string? FileName { get; set; } // Mark as nullable
    public string? CaptureDate { get; set; } // Mark as nullable
    public string? FileSize { get; set; } // Mark as nullable
    public string? Resolution { get; set; } // Mark as nullable
    public string? PhysicalBackUps { get; set; } // Mark as nullable
    public int CameraId { get; set; }
    public int UserId { get; set; }
    public Camera Camera { get; set; } = new Camera();
    public List<Location> EntryLocations { get; set; } = new List<Location>();
    public List<Tag> EntryTags { get; set; } = new List<Tag>();
}
}
