namespace Models
{

    class Competition
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}