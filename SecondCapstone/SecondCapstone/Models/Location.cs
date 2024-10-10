namespace SecondCapstone.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties for related entities
        public List<EntryLocation> EntryLocations { get; set; }
    }
}
