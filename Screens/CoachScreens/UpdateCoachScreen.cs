using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.CoachScreens
{

    public static class UpdateCoachScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Atualizando Treinador");
            Console.WriteLine("-------------------");
            var coach = GetDataCoach();
            Update(coach);

        }

        public static Coach GetDataCoach()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o Id correspondente do treinador que irá atualizar:");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido!");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
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
                Id = id,
                Name = name,
                Country = country,
                BirthDate = birthDate,
                TeamId = hasTeam.ToUpper() == "S" ? teamId : null
            };
        }

        public static void Update(Coach coach)
        {

            try
            {
                var repository = new Repository<Coach>(Database.Connection);
                repository.Update(coach);

                Console.WriteLine("|--------------------------------|");
                Console.WriteLine(" Treinador atualizado com sucesso ");
                Console.WriteLine("|--------------------------------|");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível atualizar o treinador {ex.Message}");
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