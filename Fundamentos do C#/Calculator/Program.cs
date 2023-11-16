namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("=======================FIM=========================");
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("ESCOLHAR A OPERAÇÃO DESEJADA:");
            Console.WriteLine("1 - SOMA");
            Console.WriteLine("2 - SUBTRAÇÃO");
            Console.WriteLine("3 - DIVISÃO");
            Console.WriteLine("4 - MULTIPLICAÇÃO");
            Console.WriteLine("5 - SAIR");
            Console.WriteLine("-------------------------------------------");

            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1:
                    Soma();
                    break;
                case 2:
                    Subtracao();
                    break;
                case 3:
                    Divisao();
                    break;
                case 4:
                    Multiplicao();
                    break;
                case 5:
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Selecione uma opção válida");
                    Menu();
                    break;
            }
        }
        static void Soma()
        {
            Console.Clear();
            Console.WriteLine("=======================ADIÇÃO=========================");

            Console.WriteLine("Insira o Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o Primeiro valor");
            float v2 = float.Parse(Console.ReadLine());


            float resultado = v1 + v2;

            Console.WriteLine("\n\nO Reusltado é {0}", resultado);
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("=======================SUBTRAÇÃO=========================");
            Console.WriteLine("Insira o Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o Primeiro valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 - v2;

            Console.WriteLine("\n\nO Reusltado é {0}", resultado);
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();

            Console.WriteLine("=======================SUBTRAÇÃO=========================");
            Console.WriteLine("Insira o Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o Primeiro valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 - v2;

            Console.WriteLine("\n\nO Reusltado é {0}", resultado);
            Console.ReadKey();
            Menu();
        }

        static void Multiplicao()
        {
            Console.Clear();

            Console.WriteLine("=======================SUBTRAÇÃO=========================");
            Console.WriteLine("Insira o Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Insira o Primeiro valor");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 - v2;

            Console.WriteLine("\n\nO Reusltado é {0}", resultado);
            Console.ReadKey();
            Menu();
        }
    }

}