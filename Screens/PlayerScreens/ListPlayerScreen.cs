using ClasspionsLeague.Repositories;
using ClasspionsLeague.Screens.TeamScreens;
using Models;

namespace ClasspionsLeague.Screens.PlayerScreens
{

    public static class ListPlayerScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Listar Jogadores");
            Console.WriteLine("-------------------");

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todos os Jogadores");
            Console.WriteLine("2 - Procurar Jogador por Id");
            Console.WriteLine("3 - Procurar Jogadores de um time");
            Console.WriteLine("-------------------");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: List(); break;
                case 2:
                    Console.WriteLine("Digite o Id do jogador:");
                    if (!Guid.TryParse(Console.ReadLine(), out var id))
                    {
                        Console.WriteLine("Id inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListWithId(id);
                    break;

                case 3:
                    Console.WriteLine("Digite o Id do time:");
                    if (!Guid.TryParse(Console.ReadLine(), out var teamId))
                    {
                        Console.WriteLine("Id inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListWithTeam(teamId);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadKey();
                    Console.Clear();
                    Load();
                    break;
            }
        }

        public static void List()
        {
            try
            {
                var repository = new Repository<Player>(Database.Connection);
                var players = repository.Get();

                Console.Clear();

                Console.WriteLine("|-----------------------------|");
                Console.WriteLine(" Jogadores disponíveis na base ");
                Console.WriteLine("|-----------------------------|");

                foreach (var player in players)
                {
                    Console.WriteLine($"Id: {player.Id}");
                    Console.WriteLine($"Nome: {player.Name}");
                    Console.WriteLine($"País: {player.Country}");
                    Console.WriteLine($"Data de Nascimento: {player.BirthDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Posição: {player.Position}");
                    Console.WriteLine($"Id do Time: {player.TeamId}");
                    Console.WriteLine("-------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar jogadores: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            PlayerMenu.Load();
        }

        public static void ListWithId(Guid id)
        {
            var repository = new Repository<Player>(Database.Connection);
            var player = repository.Get(id);

            Console.Clear();

            Console.WriteLine("|--------------------------------|");
            Console.WriteLine("    Jogador disponível na base    ");
            Console.WriteLine("|--------------------------------|");

            if (player != null)
            {
                Console.WriteLine($"Id: {player.Id}");
                Console.WriteLine($"Nome: {player.Name}");
                Console.WriteLine($"País: {player.Country}");
                Console.WriteLine($"Data de Nascimento: {player.BirthDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Posição: {player.Position}");
                Console.WriteLine($"Id do Time: {player.TeamId}");
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.WriteLine("Jogador não encontrado.");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            PlayerMenu.Load();
        }

        public static void ListWithTeam(Guid id)
        {

            try
            {
                var repository = new PlayerRepository(Database.Connection);
                var players = repository.GetByTeamId(id);

                foreach (var player in players)
                {
                    Console.WriteLine($"Id: {player.Id}");
                    Console.WriteLine($"Nome: {player.Name}");
                    Console.WriteLine($"País: {player.Country}");
                    Console.WriteLine($"Data de Nascimento: {player.BirthDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Posição: {player.Position}");
                    Console.WriteLine($"Id do Time: {player.TeamId}");
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar jogadores: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            PlayerMenu.Load();
        }
    }
}