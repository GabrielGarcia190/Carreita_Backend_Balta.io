namespace ExemploStrings
{
    class Program
    {

        static void Main(string[] args)
        {
            var texto = "Esse texto é um teste";

            Console.WriteLine(texto.IndexOf("é"));
            Console.WriteLine(texto.LastIndexOf("s"));
        }
        //EXEMPLO COMEÇA-COM E TERMINA-COM
        // static void Main(string[] args)
        // {
        //     var texto = "Este texto testa";
        //     Console.WriteLine(texto.StartsWith("Este"));
        //     Console.WriteLine(texto.StartsWith("Este  "));

        //     Console.WriteLine(texto.EndsWith("testa  "));
        //     Console.WriteLine(texto.EndsWith("testa"));
        //     Console.WriteLine(texto.EndsWith("Testa", StringComparison.OrdinalIgnoreCase));
        // }
        //COMPARAÇÃO DE TEXTO
        // static void Main(string[] args)
        // {
        //     Console.Clear();
        //     var texto = "Testando";
        //     Console.WriteLine(texto.CompareTo("Testando"));
        //     Console.WriteLine(texto.CompareTo("testando"));

        //     Console.WriteLine(texto.Contains("T"));
        //     Console.WriteLine(texto.Contains("E", StringComparison.OrdinalIgnoreCase));
        // }
        //EXEMPLO GUID
        // static void Main(string[] args)
        // {
        //     var id = Guid.NewGuid();

        //     Console.WriteLine(id);
        // }
    }
}