using Microsoft.Data.SqlClient;

namespace ClasspionsLeague
{

    class Program
    {
        const string connectionString = @"Server=localhost,1433;Database=ClasspionsLeague;
                                            User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main()
        {

            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                Console.WriteLine("Conexão aberta!");
            }
        }

    }
}


