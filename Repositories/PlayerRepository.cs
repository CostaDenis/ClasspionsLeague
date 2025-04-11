using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Repositories
{
    //Repositório especialista de Jogador
    public class PlayerRepository : Repository<Player>
    {

        public PlayerRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public List<Player> GetByTeamId(Guid teamId)
        {
            var query = @"SELECT * FROM Player WHERE [TeamId] = @TeamId";
            var players = _connection.Query<Player>(query, new { TeamId = teamId }).ToList<Player>();

            return players;
        }
        public List<Player> GetByName(string name)
        {
            var query = @"SELECT * FROM Player WHERE [Name] = @Name";
            var players = _connection.Query<Player>(query, new { Name = name }).ToList<Player>();

            return players;
        }
    }
}