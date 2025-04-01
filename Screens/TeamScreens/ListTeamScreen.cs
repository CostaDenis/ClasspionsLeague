using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.TeamScreens
{

    public static class ListTeamScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Listar Times");
            Console.WriteLine("-------------------");

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todos os Times");
            Console.WriteLine("2 - Procurar Time por Id");
            Console.WriteLine("3 - Procurar Time por Nome");
            Console.WriteLine("4 - Procurar Time por País");
            Console.WriteLine("-------------------");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    List();
                    break;
                case 2:
                    List();
                    break;
                case 3:
                    List();
                    break;
                case 4:
                    List();
                    break;
                default:
                    Load();
                    break;
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            TeamMenu.Load();
        }

        public static void List()
        {
            var repository = new Repository<Team>(Database.Connection);
            var teams = repository.Get();

            foreach (var team in teams)
            {
                Console.WriteLine($"Id: {team.Id}");
                Console.WriteLine($"Nome: {team.Name}");
                Console.WriteLine($"País: {team.Country}");
                Console.WriteLine("-------------------");
            }
        }

        public static void List(Guid id)
        {
            var repository = new Repository<Team>(Database.Connection);
            var teams = repository.Get();

            foreach (var team in teams)
            {
                Console.WriteLine($"Id: {team.Id}");
                Console.WriteLine($"Nome: {team.Name}");
                Console.WriteLine($"País: {team.Country}");
                Console.WriteLine("-------------------");
            }
        }
    }
}