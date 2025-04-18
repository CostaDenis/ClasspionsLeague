using ClasspionsLeague.Screens.CoachScreens;
using ClasspionsLeague.Screens.CompetitionScreens;
using ClasspionsLeague.Screens.PlayerScreens;
using ClasspionsLeague.Screens.TeamScreens;
using Microsoft.Data.SqlClient;

namespace ClasspionsLeague
{

    class Program
    {
        const string CONNECTION_STRING = @"Server=localhost,1433;Database=ClasspionsLeague;
                                            User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";

        static void Main()
        {
            Console.Clear();
            OpenConnection();

            Console.WriteLine("|-------------------|");
            Console.WriteLine("  Classpions League  ");
            Console.WriteLine("|-------------------|");
            Console.WriteLine();

            Load();

        }

        public static void Load()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Times");
            Console.WriteLine("2 - Jogadores");
            Console.WriteLine("3 - Treinadores");
            Console.WriteLine("4 - Competições");
            Console.WriteLine("5 - Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    TeamMenu.Load();
                    break;
                case 2:
                    PlayerMenu.Load();
                    break;
                case 3:
                    CoachMenu.Load();
                    break;
                case 4:
                    CompetitionMenu.Load();
                    break;
                case 5:
                    CloseConnection();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    Console.Clear();
                    Load();
                    break;
            }

        }

        public static void OpenConnection()
        {
            if (Database.Connection.State == System.Data.ConnectionState.Closed)
            {
                Database.Connection = new SqlConnection(CONNECTION_STRING);
                Database.Connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (Database.Connection.State == System.Data.ConnectionState.Open)
            {
                Database.Connection.Dispose();
                Console.WriteLine("Conexão encerrada com sucesso!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}


