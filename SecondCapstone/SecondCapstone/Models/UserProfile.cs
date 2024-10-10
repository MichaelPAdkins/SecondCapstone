namespace SecondCapstone.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Navigation properties for related entities
        public List<Entry> Entries { get; set; }
    }
}
