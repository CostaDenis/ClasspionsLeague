using ClasspionsLeague.Repositories;
using ClasspionsLeague.Screens.TeamScreens;
using Models;

namespace ClasspionsLeague.Screens.CoachScreens
{

    public static class ListCoachScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Listar Treinadores");
            Console.WriteLine("-------------------");

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Listar todos os Treinadores");
            Console.WriteLine("2 - Procurar Treinador por Id");
            Console.WriteLine("3 - Procurar Treinador por Nome");
            Console.WriteLine("4 - Procurar Treinador de um time");
            Console.WriteLine("-------------------");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: List(); break;
                case 2:
                    Console.WriteLine("Digite o Id do treinador:");
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
                    Console.WriteLine("Digite o nome do treinador:");
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
                    Console.WriteLine("Digite o Id do time:");
                    if (!Guid.TryParse(Console.ReadLine(), out var teamId))
                    {
                        Console.WriteLine("Id inválido!");
                        Console.ReadKey();
                        Console.Clear();
                        Load();
                    }
                    ListWithTeam(teamId);
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
                var repository = new Repository<Coach>(Database.Connection);
                var coaches = repository.Get();

                Console.Clear();

                Console.WriteLine("|-------------------------------|");
                Console.WriteLine(" Treinadores disponíveis na base ");
                Console.WriteLine("|-------------------------------|");

                foreach (var coach in coaches)
                {
                    Console.WriteLine($"Id: {coach.Id}");
                    Console.WriteLine($"Nome: {coach.Name}");
                    Console.WriteLine($"País: {coach.Country}");
                    Console.WriteLine($"Data de Nascimento: {coach.BirthDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Id do Time: {coach.TeamId}");
                    Console.WriteLine("-------------------");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao listar treinadores");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CoachMenu.Load();
        }

        public static void ListWithId(Guid id)
        {
            var repository = new Repository<Coach>(Database.Connection);
            var coach = repository.Get(id);

            Console.Clear();

            Console.WriteLine("|--------------------------------|");
            Console.WriteLine("   Treinador disponível na base   ");
            Console.WriteLine("|--------------------------------|");

            if (coach != null)
            {
                Console.WriteLine($"Id: {coach.Id}");
                Console.WriteLine($"Nome: {coach.Name}");
                Console.WriteLine($"País: {coach.Country}");
                Console.WriteLine($"Data de Nascimento: {coach.BirthDate.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Id do Time: {coach.TeamId}");
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.WriteLine("Treinador não encontrado.");
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CoachMenu.Load();
        }

        public static void ListWithTeam(Guid id)
        {

            try
            {
                var repository = new CoachRepository(Database.Connection);
                var coaches = repository.GetByTeamId(id);

                Console.WriteLine("|----------------------------|");
                Console.WriteLine(" Treinador disponível na base ");
                Console.WriteLine("|----------------------------|");

                if (coaches.Count == 0)
                {
                    Console.WriteLine("Nenhum treinador encontrado na base.");
                    Console.ReadKey();
                    Console.Clear();
                    Load();
                }

                foreach (var coach in coaches)
                {
                    Console.WriteLine($"Id: {coach.Id}");
                    Console.WriteLine($"Nome: {coach.Name}");
                    Console.WriteLine($"País: {coach.Country}");
                    Console.WriteLine($"Data de Nascimento: {coach.BirthDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Id do Time: {coach.TeamId}");
                    Console.WriteLine("-------------------");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao listar treinador");
                Console.ReadKey();
                Console.Clear();
                Load();
            }

            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
            CoachMenu.Load();
        }

        public static void ListWithName(string name)
        {

            try
            {
                var repository = new CoachRepository(Database.Connection);
                var coaches = repository.GetByName(name);

                if (coaches.Count == 0)
                {
                    Console.WriteLine("|-----------------------------------|");
                    Console.WriteLine(" Nenhum treinador encontrado na base ");
                    Console.WriteLine("|-----------------------------------|");

                    Console.ReadKey();
                    Console.Clear();
                    Load();
                }

                Console.WriteLine("|-----------------------------------|");
                Console.WriteLine(" Treinador(es) encontrado(s) na base ");
                Console.WriteLine("|-----------------------------------|");

                foreach (var coach in coaches)
                {
                    Console.WriteLine($"Id: {coach.Id}");
                    Console.WriteLine($"Nome: {coach.Name}");
                    Console.WriteLine($"País: {coach.Country}");
                    Console.WriteLine($"Data de Nascimento: {coach.BirthDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Id do Time: {coach.TeamId}");
                    Console.WriteLine("-------------------");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erro ao listar treinadores");
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