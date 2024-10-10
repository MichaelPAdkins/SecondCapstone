namespace SecondCapstone.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation properties for related entities
        public List<EntryTag> EntryTags { get; set; }
    }
}
