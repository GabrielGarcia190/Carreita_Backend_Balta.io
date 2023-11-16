namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("=============INICIO===========");
            Console.WriteLine("ESCOLHA A OPÇÃO DESEJADA: ");
            Console.WriteLine("1 - ABRIR ARQUIVO");
            Console.WriteLine("2 - CRIAR NOVO ARQUIVO");
            Console.WriteLine("0 - SAIR");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    break;
            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("INSIRA O CAMINHO DO ARQUIVO");
            string? _path = Console.ReadLine();

            using (var file = new StreamReader(_path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Menu();
        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("DIGITE SEU TEXTO ABAIXO (ESC PARA SAIR):");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine(" INSIRA O CAMINHO PARA SALVAR O ARQUIVO");
            var _path = Console.ReadLine();

            using (var file = new StreamWriter(_path))
            {
                file.Write(text);
            }
            Console.WriteLine($"ARQUIVO SALVO EM: {_path}");

            Menu();
        }
    }
}