namespace SecondCapstone.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties for related entities
        public List<Entry> Entries { get; set; }
    }
}
