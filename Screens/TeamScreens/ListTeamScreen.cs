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
            Console.WriteLine("2 - Procurar Time por Nome");
            Console.WriteLine("-------------------");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    List();
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Digite o Id do time:");
                    var id = Guid.Parse(Console.ReadLine()!);

                    ListWithId(id);
                    break;
                case 3:
                    Console.WriteLine("Digite o nome do time:");
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

                default:
                    Load();
                    break;
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            TeamMenu.Load();
        }

        public static void List()
        {
            var repository = new Repository<Team>(Database.Connection);
            var teams = repository.Get();

            Console.Clear();

            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("   Time disponíveis na base   ");
            Console.WriteLine("|-----------------------------|");

            foreach (var team in teams)
            {
                Console.WriteLine($"Id: {team.Id}");
                Console.WriteLine($"Nome: {team.Name}");
                Console.WriteLine($"País: {team.Country}");
                Console.WriteLine("-------------------");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            TeamMenu.Load();
        }

        public static void ListWithId(Guid id)
        {
            var repository = new Repository<Team>(Database.Connection);
            var team = repository.Get(id);

            Console.Clear();

            Console.WriteLine("|----------------------------|");
            Console.WriteLine("    Time encontrado na base    ");
            Console.WriteLine("|----------------------------|");

            Console.WriteLine($"Id: {team.Id}");
            Console.WriteLine($"Nome: {team.Name}");
            Console.WriteLine($"País: {team.Country}");

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            TeamMenu.Load();

        }

        public static void ListWithName(string name)
        {

            try
            {
                var repository = new TeamRepository(Database.Connection);
                var teams = repository.GetByName(name);

                if (teams.Count == 0)
                {
                    Console.WriteLine("|-------------------------------------|");
                    Console.WriteLine("    Nenhum time encontrado na base    ");
                    Console.WriteLine("|-------------------------------------|");

                    Console.ReadKey();
                    Console.Clear();
                    Load();
                }

                Console.WriteLine("|----------------------------------|");
                Console.WriteLine("   Time(s) encontrado(s) na base   ");
                Console.WriteLine("|----------------------------------|");

                foreach (var team in teams)
                {
                    Console.WriteLine($"Id: {team.Id}");
                    Console.WriteLine($"Nome: {team.Name}");
                    Console.WriteLine($"País: {team.Country}");
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro ao listar times");
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