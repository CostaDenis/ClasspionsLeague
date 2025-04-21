using ClasspionsLeague.Repositories;
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
            Console.WriteLine("3 - Procurar Jogador por Nome");
            Console.WriteLine("4 - Procurar Jogadores de um time");
            Console.WriteLine();
            Console.Write("Opção: ");
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
                    Console.WriteLine("Digite o nome do jogador:");
                    var name = Console.ReadLine()!;
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Nome inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListWithName(name);
                    break;
                case 4:
                    Console.WriteLine("Digite o Id do time:");
                    if (!Guid.TryParse(Console.ReadLine(), out var teamId))
                    {
                        Console.WriteLine("Id inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListByTeamId(teamId);
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

        public static void ListWithName(string name)
        {

            try
            {
                var repository = new PlayerRepository(Database.Connection);
                var players = repository.GetByName(name);

                if (players.Count == 0)
                {
                    Console.WriteLine("|------------------------------------|");
                    Console.WriteLine("  Nenhum jogador encontrado na base  ");
                    Console.WriteLine("|------------------------------------|");

                    Console.ReadKey();
                    Console.Clear();
                    Load();
                }

                Console.WriteLine("|----------------------------------|");
                Console.WriteLine(" Jogadore(s) encontrado(s) na base ");
                Console.WriteLine("|----------------------------------|");

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

        public static void ListByTeamId(Guid id)
        {

            try
            {
                var repository = new PlayerRepository(Database.Connection);
                var players = repository.GetByTeamId(id);

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

    }
}