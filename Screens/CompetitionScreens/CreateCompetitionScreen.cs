using ClasspionsLeague.Repositories;
using Microsoft.Data.SqlClient;
using Models;

namespace ClasspionsLeague.Screens.CompetitionScreens
{

    public static class CreateCompetitionScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Nova Competição");
            Console.WriteLine("-------------------");
            var competition = GetDataCompetition();
            Create(competition);
        }

        public static Competition GetDataCompetition()
        {
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
                Id = Guid.NewGuid(),
                Name = name,
                Country = country,
                Teams = new List<Team>()
            };
        }

        public static void Create(Competition competition)
        {

            try
            {
                var repository = new CompetitionRepository(Database.Connection);
                repository.CreateCompetition(competition);

                Console.WriteLine("|-------------------------------|");
                Console.WriteLine("  Competição criada com sucesso  ");
                Console.WriteLine("|-------------------------------|");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)  //Exceção de chave primária duplicada
            {
                Console.WriteLine($"O Identificador: '{competition.Id}' já existe.");
                Console.WriteLine("Tente novamente com um novo identificador.");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar competição: {ex.Message}");
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