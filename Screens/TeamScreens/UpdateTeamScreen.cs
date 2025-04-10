using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.TeamScreens
{

    public class UpdateTeamScreen
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Atualizando Time");
            Console.WriteLine("-------------------");

            Console.WriteLine("Informe a Id do Time: ");
            var id = Console.ReadLine()!;
            Console.WriteLine("Informe o nome do Time: ");
            var name = Console.ReadLine()!;
            Console.WriteLine("Informe o País do time: ");
            var country = Console.ReadLine()!;

            try
            {
                Update(new Team
                {
                    Id = Guid.Parse(id),
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

        public static void Update(Team team)
        {

            if (team.Name == null || team.Country == null)
            {
                Console.WriteLine("Nome ou País não pode ser nulo");
                return;
            }

            try
            {
                var repository = new Repository<Team>(Database.Connection);
                repository.Update(team);

                Console.WriteLine("|------------------------------|");
                Console.WriteLine("  Time atualizado com sucesso  ");
                Console.WriteLine("|------------------------------|");
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível atualizar o time");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            TeamMenu.Load();
        }
    }
}