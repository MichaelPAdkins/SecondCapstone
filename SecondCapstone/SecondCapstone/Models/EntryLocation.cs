namespace SecondCapstone.Models
{
    public class EntryLocation
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public Entry Entry { get; set; }

        public int LocationsId { get; set; }
        public Location Location { get; set; }
    }
}
