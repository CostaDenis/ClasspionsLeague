using ClasspionsLeague.Enums;
using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("[Player]")]
    public class Player
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Position { get; set; } = string.Empty;
        public Guid? TeamId { get; set; }
    }
}