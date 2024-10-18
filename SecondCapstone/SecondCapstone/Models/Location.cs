namespace SecondCapstone.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Marking EntryLocations as optional (it can be null)
        public List<EntryLocation>? EntryLocations { get; set; }
    }
}
