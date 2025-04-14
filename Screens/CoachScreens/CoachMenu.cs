using ClasspionsLeague.Screens.CoachScreens;
using ClasspionsLeague.Screens.PlayerScreens;

namespace ClasspionsLeague.Screens.TeamScreens
{

    public static class CoachMenu
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Menu - Treinador");
            Console.WriteLine("-------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Treinadores");
            Console.WriteLine("2 - Cadastrar Treinador");
            Console.WriteLine("3 - Atualizar Treinador");
            Console.WriteLine("4 - Deletar Treinador");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("0 - Encerrar programa");
            Console.WriteLine();
            Console.WriteLine("-------------------");

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {

                case 1:
                    ListCoachScreen.Load();
                    break;

                case 2:
                    CreateCoachScreen.Load();
                    break;

                case 3:
                    UpdatePlayerScreen.Load();
                    break;

                case 4:
                    DeletePlayerScreen.Load();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Load();
                    break;

            }

        }

    }
}