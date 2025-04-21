using ClasspionsLeague.Repositories;
using ClasspionsLeague.Screens.CompetitionScreens;
using Models;

namespace ClasspionsLeague.Screens.CompetitionScreensScreens
{

    public static class ListCompetitionScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Listar Competições");
            Console.WriteLine("-------------------");

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todas as Competições");
            Console.WriteLine("2 - Procurar Competição por Id");
            Console.WriteLine("3 - Procurar Competição por Nome");
            Console.WriteLine("4 - Procurar Competições com Times");
            Console.WriteLine();
            Console.Write("Opção: ");
            Console.WriteLine("-------------------");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: List(); break;
                case 2:
                    Console.WriteLine("Digite o Id da competição:");
                    if (!Guid.TryParse(Console.ReadLine(), out var id))
                    {
                        Console.WriteLine("Id inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListWithId(id);
                    break;

                case 3:
                    Console.WriteLine("Digite o nome da competição:");
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
                case 4:
                    ListWithTeam();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.ReadKey();
                    Console.Clear();
                    Load();
                    break;
            }
        }

        public static void List()
        {
            try
            {
                var repository = new Repository<Competition>(Database.Connection);
                var competitions = repository.Get();

                Console.Clear();

                Console.WriteLine("|-------------------------------|");
                Console.WriteLine(" Competições disponíveis na base ");
                Console.WriteLine("|-------------------------------|");

                foreach (var competition in competitions)
                {
                    Console.WriteLine($"Id: {competition.Id}");
                    Console.WriteLine($"Nome: {competition.Name}");
                    Console.WriteLine($"País: {competition.Country}");
                    Console.WriteLine("-------------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar competições: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CompetitionMenu.Load();
        }

        public static void ListWithId(Guid id)
        {
            var repository = new Repository<Competition>(Database.Connection);
            var competition = repository.Get(id);

            Console.Clear();

            Console.WriteLine("|-------------------------------|");
            Console.WriteLine("  Competição disponível na base  ");
            Console.WriteLine("|-------------------------------|");

            if (competition != null)
            {
                Console.WriteLine($"Id: {competition.Id}");
                Console.WriteLine($"Nome: {competition.Name}");
                Console.WriteLine($"País: {competition.Country}");
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.WriteLine("Competição não encontrada.");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CompetitionMenu.Load();
        }

        public static void ListWithName(string name)
        {

            try
            {
                var repository = new CompetitionRepository(Database.Connection);
                var competitions = repository.GetByName(name);

                if (competitions.Count == 0)
                {
                    Console.WriteLine("|---------------------------------------|");
                    Console.WriteLine("  Nenhuma competição encontrada na base  ");
                    Console.WriteLine("|---------------------------------------|");

                    Console.ReadKey();
                    Console.Clear();
                    Load();
                }

                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine(" Competição(ões) encontrada(s) na base ");
                Console.WriteLine("|-------------------------------------|");

                foreach (var competition in competitions)
                {
                    Console.WriteLine($"Id: {competition.Id}");
                    Console.WriteLine($"Nome: {competition.Name}");
                    Console.WriteLine($"País: {competition.Country}");
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar competições: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CompetitionMenu.Load();
        }

        public static void ListWithTeam()
        {

            try
            {
                var repository = new CompetitionRepository(Database.Connection);
                var competitions = repository.GetWithTeam();

                Console.WriteLine("|-------------------------------|");
                Console.WriteLine(" Competições disponíveis na base ");
                Console.WriteLine("|-------------------------------|");

                foreach (var competition in competitions)
                {
                    Console.WriteLine(competition.Name);

                    foreach (var team in competition.Teams)
                        Console.WriteLine($" - {team.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar competições: {ex.Message}");
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