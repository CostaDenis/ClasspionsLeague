namespace ClasspionsLeague.Screens.TeamScreens
{

    public static class TeamMenu
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Menu - Times");
            Console.WriteLine("-------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Times");
            Console.WriteLine("2 - Cadastrar Time");
            Console.WriteLine("3 - Atualizar Time");
            Console.WriteLine("4 - Deletar Time");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("0 - Encerrar programa");
            Console.WriteLine();
            Console.WriteLine("-------------------");

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {

                case 1:
                    ListTeamScreen.Load();
                    break;

                case 2:
                    CreateTeamScreen.Load();
                    break;

                case 3:
                    UpdateTeamScreen.Load();
                    break;

                case 4:
                    DeleteTeamScreen.Load();
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