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

        //Não é possível alterar a conexão
        private readonly SqlConnection _connection;

        public List<Player> GetByTeamId(Guid teamId)
        {
            var query = @"SELECT * FROM Player WHERE TeamId = @TeamId";
            var players = _connection.Query<Player>(query, new { TeamId = teamId }).ToList<Player>();

            return players;
        }
    }
}