using ClasspionsLeague.Enums;
using ClasspionsLeague.Repositories;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Screens.PlayerScreens
{

    public static class CreatePlayerScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Novo Jogador");
            Console.WriteLine("-------------------");
            var player = GetDataPlayer();
            Create(player);
        }

        public static Player GetDataPlayer()
        {
            Console.WriteLine();
            Console.WriteLine("Informe o nome do Jogador: ");
            var name = Console.ReadLine()!;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataPlayer();
            }
            Console.WriteLine();

            Console.WriteLine("Informe o País: ");
            var country = Console.ReadLine()!;
            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("País inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataPlayer();
            }
            Console.WriteLine();

            Console.WriteLine("Informe a data de nascimento: ");
            var inputDate = Console.ReadLine()!;

            if (!DateTime.TryParseExact(
                    inputDate,
                    "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var birthDate))
            {
                Console.WriteLine("Data inválida! Use o formato yyyy-MM-dd.");
                Console.ReadKey();
                Console.Clear();
                GetDataPlayer();
            }
            Console.WriteLine();

            Console.WriteLine("Informe a posição: ");
            Console.WriteLine("1 - Goleiro");
            Console.WriteLine("2 - Zagueiro");
            Console.WriteLine("3 - Meio Campo");
            Console.WriteLine("4 - Atacante");
            var positionInput = Console.ReadLine()!;

            EPlayer position = EPlayer.Goalkeeper; // Valor padrão 

            switch (positionInput)
            {
                case "1":
                    position = EPlayer.Goalkeeper; break;
                case "2":
                    position = EPlayer.Defender; break;
                case "3":
                    position = EPlayer.Midfielder; break;
                case "4":
                    position = EPlayer.Forward; break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    Console.Clear();
                    GetDataPlayer();
                    break;
            }
            Console.WriteLine();

            var hasTeam = string.Empty;
            do
            {
                Console.WriteLine("O jogador possui time? (S/N): ");
                hasTeam = Console.ReadLine()!;
            } while (hasTeam.ToUpper() != "S" && hasTeam.ToUpper() != "N");
            Console.WriteLine();

            Guid? teamId = null;
            if (hasTeam.ToUpper() == "S")
            {
                Console.WriteLine("Informe o Id do time: ");

                if (!Guid.TryParse(Console.ReadLine(), out var parsedTeamId))
                {
                    Console.WriteLine("Id inválido!");
                    Console.ReadKey();
                    Console.Clear();
                    GetDataPlayer();
                }
                Console.WriteLine();

                var teamRepository = new Repository<Team>(Database.Connection);
                var team = teamRepository.Get(parsedTeamId);

                if (team == null)  //Verifica se existe o time com o Id fornecido
                {
                    Console.WriteLine("Time não encontrado!");
                    Console.ReadKey();
                    Console.Clear();
                    GetDataPlayer();
                }
                teamId = parsedTeamId;
            }
            Console.WriteLine();

            return new Player
            {
                Id = Guid.NewGuid(),
                Name = name,
                Country = country,
                BirthDate = birthDate,
                Position = position.ToString(),
                TeamId = hasTeam.ToUpper() == "S" ? teamId : null
            };
        }

        public static void Create(Player player)
        {

            try
            {
                var repository = new Repository<Player>(Database.Connection);
                repository.Create(player);

                Console.WriteLine("|------------------------------|");
                Console.WriteLine("   Jogador criado com sucesso   ");
                Console.WriteLine("|------------------------------|");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)  //Exceção de chave primária duplicada
            {
                Console.WriteLine($"O Identificador: '{player.Id}' já existe.");
                Console.WriteLine("Tente novamente com um novo identificador.");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar jogador: " + ex.Message);
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