using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Repositories
{
    //Repositório especialista de Time
    public class TeamRepository : Repository<Player>
    {

        public TeamRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public List<Team> GetByName(string name)
        {
            var query = @"SELECT * FROM [Team] WHERE LTRIM(RTRIM([Name])) LIKE @Name";
            var teams = _connection.Query<Team>(query, new { Name = $"%{name}%" }).ToList<Team>();

            return teams;
        }
    }
}