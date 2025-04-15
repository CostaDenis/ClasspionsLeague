using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("[Competition]")]
    public class Competition
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}