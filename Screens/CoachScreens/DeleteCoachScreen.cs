using ClasspionsLeague.Repositories;
using Models;

namespace ClasspionsLeague.Screens.CoachScreens
{

    public static class DeleteCoachScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Deletar Treinador");
            Console.WriteLine("-------------------");
            Console.WriteLine("Informe o Id do Treinador: ");
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
                var repository = new Repository<Coach>(Database.Connection);
                var coach = repository.Get(id);

                if (coach != null)
                {
                    repository.Delete(coach);

                    Console.WriteLine("|------------------------------|");
                    Console.WriteLine(" Treinador deletado com sucesso ");
                    Console.WriteLine("|------------------------------|");
                }
                else
                {
                    Console.WriteLine("Treinador não encontrado.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível excluir o treinador");
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