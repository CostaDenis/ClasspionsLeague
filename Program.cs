using ClasspionsLeague.Repositories;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague
{

    class Program
    {
        const string connectionString = @"Server=localhost,1433;Database=ClasspionsLeague;
                                            User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main()
        {
            Console.Clear();
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();

                ReadTeams(connection); //teste

                Console.Read();
                Console.Clear();

            }
        }

        public static void ReadTeams(SqlConnection connection)
        {
            var teamRepository = new Repository<Team>(connection);
            var teams = teamRepository.Get();

            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
            }
        }

    }
}


