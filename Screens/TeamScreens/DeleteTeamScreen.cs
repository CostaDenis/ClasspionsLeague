using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.TeamScreens
{

    public static class DeleteTeamScreen
    {
        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Deletar Time");
            Console.WriteLine("-------------------");
            Console.WriteLine("Informe o Id do Time: ");
            var id = Console.ReadLine()!;

            try
            {
                Delete(Guid.Parse(id));
            }
            catch (FormatException)
            {
                Console.WriteLine("Id inválido!");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

        }

        public static void Delete(Guid id)
        {

            try
            {
                var repository = new Repository<Team>(Database.Connection);
                var team = repository.Get(id);

                if (team != null)
                {
                    repository.Delete(team);

                    Console.WriteLine("|------------------------------|");
                    Console.WriteLine("   Time deletado com sucesso   ");
                    Console.WriteLine("|------------------------------|");
                }
                else
                {
                    Console.WriteLine("Time não encontrado.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível excluir o time");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            TeamMenu.Load();
        }
    }
}