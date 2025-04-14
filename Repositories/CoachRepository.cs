using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Repositories
{
    //Repositório especialista de Time
    public class CoachRepository : Repository<Coach>
    {

        public CoachRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public List<Coach> GetByTeamId(Guid teamId)
        {
            var query = @"SELECT * FROM [Coach] WHERE [TeamId] = @TeamId";
            var coach = _connection.Query<Coach>(query, new { TeamId = teamId }).ToList<Coach>();

            return coach;
        }

        public List<Coach> GetByName(string name)
        {
            var query = @"SELECT * FROM [Coach] WHERE LTRIM(RTRIM([Name])) LIKE @Name";
            var coachs = _connection.Query<Coach>(query, new { Name = $"%{name}%" }).ToList<Coach>();

            return coachs;
        }
    }
}