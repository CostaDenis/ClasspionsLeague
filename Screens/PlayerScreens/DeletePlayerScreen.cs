using ClasspionsLeague.Repositories;
using ClasspionsLeague.Screens.TeamScreens;
using Models;

namespace ClasspionsLeague.Screens.PlayerScreens
{

    public static class DeletePlayerScreen
    {

        public static void Load()
        {
            Console.Clear();

            Console.WriteLine("Deletar Jogador");
            Console.WriteLine("-------------------");
            Console.WriteLine("Informe o Id do Jogador: ");
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
                var repository = new Repository<Player>(Database.Connection);
                var player = repository.Get(id);

                if (player != null)
                {
                    repository.Delete(player);

                    Console.WriteLine("|------------------------------|");
                    Console.WriteLine("   Jogador deletado com sucesso   ");
                    Console.WriteLine("|------------------------------|");
                }
                else
                {
                    Console.WriteLine("Jogador não encontrado.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível excluir o jogador");
                Console.WriteLine("Id inválido!");
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