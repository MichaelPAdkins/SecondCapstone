namespace SecondCapstone.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Make EntryTags optional by using "?" for a nullable reference type or initializing as an empty list.
        public List<EntryTag>? EntryTags { get; set; } = new List<EntryTag>();
    }
}
