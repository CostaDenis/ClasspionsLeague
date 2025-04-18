namespace ClasspionsLeague.Screens.PlayerScreens
{

    public static class PlayerMenu
    {

        public static void Load()
        {

            Console.Clear();

            Console.WriteLine("Menu - Jogador");
            Console.WriteLine("-------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Jogadores");
            Console.WriteLine("2 - Cadastrar Jogador");
            Console.WriteLine("3 - Atualizar Jogador");
            Console.WriteLine("4 - Deletar Jogador");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("0 - Encerrar programa");
            Console.WriteLine();
            Console.WriteLine("-------------------");

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {

                case 1:
                    ListPlayerScreen.Load();
                    break;

                case 2:
                    CreatePlayerScreen.Load();
                    break;

                case 3:
                    UpdatePlayerScreen.Load();
                    break;

                case 4:
                    DeletePlayerScreen.Load();
                    break;

                case 5:
                    Program.Load();
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