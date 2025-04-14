using ClasspionsLeague.Repositories;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Screens.CoachScreens
{

    public static class CreateCoachScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Novo Treinador");
            Console.WriteLine("-------------------");
            var coach = GetDataCoach();
            Create(coach);
        }

        public static Coach GetDataCoach()
        {
            Console.WriteLine();
            Console.WriteLine("Informe o nome do Treinador: ");
            var name = Console.ReadLine()!;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataCoach();
            }
            Console.WriteLine();

            Console.WriteLine("Informe o País: ");
            var country = Console.ReadLine()!;
            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("País inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataCoach();
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
                GetDataCoach();
            }
            Console.WriteLine();

            var hasTeam = string.Empty;
            do
            {
                Console.WriteLine("O treinador possui time? (S/N): ");
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
                    GetDataCoach();
                }
                Console.WriteLine();

                var teamRepository = new Repository<Team>(Database.Connection);
                var team = teamRepository.Get(parsedTeamId);

                if (team == null)  //Verifica se existe o time com o Id fornecido
                {
                    Console.WriteLine("Time não encontrado!");
                    Console.ReadKey();
                    Console.Clear();
                    GetDataCoach();
                }
                teamId = parsedTeamId;
            }
            Console.WriteLine();

            return new Coach
            {
                Id = Guid.NewGuid(),
                Name = name,
                Country = country,
                BirthDate = birthDate,
                TeamId = hasTeam.ToUpper() == "S" ? teamId : null
            };
        }

        public static void Create(Coach coach)
        {

            try
            {
                var repository = new Repository<Coach>(Database.Connection);
                repository.Create(coach);

                Console.WriteLine("|------------------------------|");
                Console.WriteLine("  Treinador criado com sucesso  ");
                Console.WriteLine("|------------------------------|");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)  //Exceção de chave primária duplicada
            {
                Console.WriteLine($"O Identificador: '{coach.Id}' já existe.");
                Console.WriteLine("Tente novamente com um novo identificador.");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar treinador: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CoachMenu.Load();

        }
    }
}