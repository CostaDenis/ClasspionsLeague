using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Repositories
{
    //Repositório especialista de Time
    public class CompetitionRepository : Repository<Competition>
    {

        public CompetitionRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        private readonly SqlConnection _connection;

        public List<Competition> GetWithTeam()  //Lista as competições com os times
        {
            var query = @"SELECT 
                            [Competition].*,
                            [Team].*
                          FROM
                            [Competition]
                            LEFT JOIN [CompetitionTeam] ON [CompetitionTeam].[CompetitionId] = [Competition].[Id]
                            LEFT JOIN [Team] ON [CompetitionTeam].[TeamId] = [Team].[Id]";

            var competitions = new List<Competition>();

            var items = _connection.Query<Competition, Team, Competition>(
                    query,
                    (competition, team) =>
                    {
                        var cmp = competitions.FirstOrDefault(x => x.Id == competition.Id);

                        if (cmp == null)
                        {
                            cmp = competition;
                            if (team != null)
                                cmp.Teams.Add(team);

                            competitions.Add(cmp);
                        }
                        else
                        {
                            cmp.Teams.Add(team);
                        }

                        return competition;
                    }, splitOn: "Id");

            return competitions;

        }

        public List<Competition> GetByName(string name)
        {
            var query = @"SELECT * FROM [Competition] WHERE LTRIM(RTRIM([Name])) LIKE @Name";
            var competitions = _connection.Query<Competition>(query, new { Name = $"%{name}%" }).ToList<Competition>();

            return competitions;
        }

        public void CreateCompetition(Competition competition)
        {
            var query = @"INSERT INTO [Competition] ([Id], [Name], [Country]) VALUES (@Id, @Name, @Country)";
            _connection.Execute(query, competition);
        }

        public void UpdateCompetition(Competition competition)
        {
            var query = @"UPDATE [Competition] SET [Name] = @Name, [Country] = @Country WHERE [Id] = @Id";
            _connection.Execute(query, competition);
        }
    }
}