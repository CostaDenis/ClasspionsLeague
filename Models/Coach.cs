using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("[Coach]")]
    class Coach
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public Guid TeamId { get; set; }
    }
}