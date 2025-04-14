using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("[Coach]")]
    public class Coach
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Guid? TeamId { get; set; }
    }
}