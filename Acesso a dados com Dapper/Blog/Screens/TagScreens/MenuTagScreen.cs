namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Tags");
            Console.WriteLine("-------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar Tags");
            Console.WriteLine("3 - Atualizar Tags");
            Console.WriteLine("4 - Deletar Tags");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListTagScreen.Load();
                    break;

                case 2:
                    CreateTagScreen.Load();
                    break;

                case 3:
                    UpdateTagScreens.Load();
                    break;

                case 4:
                    DeleteTagScreen.Load();
                    break;

                default:
                    Load();
                    break;
            }
        }
    }
}