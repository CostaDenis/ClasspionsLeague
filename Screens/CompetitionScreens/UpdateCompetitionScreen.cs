using ClasspionsLeague.Repositories;
using ClasspionsLeague.Screens.CompetitionScreens;
using Models;

namespace ClasspionsLeague.Screens.CompetitionScreensScreens
{

    public static class UpdateCompetitionScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Atualizando Competição");
            Console.WriteLine("-------------------");
            var competition = GetDataCompetition();
            Update(competition);

        }

        public static Competition GetDataCompetition()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o Id correspondente da competição que irá atualizar:");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido!");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            Console.WriteLine();

            Console.WriteLine("Informe o nome da Competição: ");
            var name = Console.ReadLine()!;
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataCompetition();
            }
            Console.WriteLine();

            Console.WriteLine("Informe o País: ");
            var country = Console.ReadLine()!;
            if (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("País inválido!");
                Console.ReadKey();
                Console.Clear();
                GetDataCompetition();
            }
            Console.WriteLine();

            return new Competition
            {
                Id = id,
                Name = name,
                Country = country,
            };
        }

        public static void Update(Competition competition)
        {

            try
            {
                var repository = new CompetitionRepository(Database.Connection);
                repository.UpdateCompetition(competition);

                Console.WriteLine("|---------------------------------|");
                Console.WriteLine(" Competição atualizada com sucesso ");
                Console.WriteLine("|---------------------------------|");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível atualizar a competição: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CompetitionMenu.Load();
        }
    }
}