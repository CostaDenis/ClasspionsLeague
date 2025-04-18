using ClasspionsLeague.Screens.CompetitionScreensScreens;

namespace ClasspionsLeague.Screens.CompetitionScreens
{

    public static class CompetitionMenu
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Menu - Competição");
            Console.WriteLine("-------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Competições");
            Console.WriteLine("2 - Cadastrar Competição");
            Console.WriteLine("3 - Atualizar Competição");
            Console.WriteLine("4 - Deletar Competição");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("0 - Encerrar programa");
            Console.WriteLine();
            Console.WriteLine("-------------------");

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {

                case 1:
                    ListCompetitionScreen.Load();
                    break;

                case 2:
                    CreateCompetitionScreen.Load();
                    break;

                case 3:
                    UpdateCompetitionScreen.Load();
                    break;

                case 5:
                    Program.Load();
                    break;

                case 4:
                    DeleteCompetitionScreen.Load();
                    break;

                case 0:
                    Program.CloseConnection();
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    Console.Clear();
                    Load();
                    break;

            }

        }

    }
}