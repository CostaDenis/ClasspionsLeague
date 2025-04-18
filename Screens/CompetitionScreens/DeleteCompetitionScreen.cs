using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.CompetitionScreens
{

    public static class DeleteCompetitionScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Deletar Competição");
            Console.WriteLine("-------------------");
            Console.WriteLine("Informe o Id da Competição: ");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Id inválido!");
                Console.ReadKey();
                Console.Clear();
                Load();
            }
            Delete(id);
        }

        public static void Delete(Guid id)
        {

            try
            {
                var repository = new Repository<Competition>(Database.Connection);
                var competition = repository.Get(id);

                if (competition != null)
                {
                    repository.Delete(competition);

                    Console.WriteLine("|-------------------------------|");
                    Console.WriteLine(" Competição deletada com sucesso ");
                    Console.WriteLine("|-------------------------------|");
                }
                else
                {
                    Console.WriteLine("Competição não encontrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível excluir a Competição: {ex.Message}");
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