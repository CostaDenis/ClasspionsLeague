using Models;
using ClasspionsLeague.Repositories;
using Microsoft.Data.SqlClient;

namespace ClasspionsLeague.Screens.TeamScreens
{

    public static class CreateTeamScreen
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Novo Time");
            Console.WriteLine("-------------------");
            Console.WriteLine("Informe o nome da Time: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Informe o País: ");
            var country = Console.ReadLine()!;

            try
            {
                Create(new Team
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Country = country
                });
            }
            catch (FormatException)
            {
                Console.WriteLine("Id inválido!");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
        }

        public static void Create(Team team)
        {
            if (string.IsNullOrEmpty(team.Name) || string.IsNullOrEmpty(team.Country))
            {
                Console.WriteLine("Nome e País não podem ser vazios.");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            try
            {
                var repository = new Repository<Team>(Database.Connection);
                repository.Create(team);

                Console.WriteLine("|------------------------------|");
                Console.WriteLine("    Time criado com sucesso    ");
                Console.WriteLine("|------------------------------|");

            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)  //Exceção de chave primária duplicada
            {
                Console.WriteLine($"O Identificador: '{team.Id}' já existe.");
                Console.WriteLine("Tente novamente com um novo identificador.");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar time: {ex.Message}");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            TeamMenu.Load();
        }
    }
}