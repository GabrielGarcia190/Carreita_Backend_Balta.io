
namespace Execptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3];

            try
            {
                // for (var index = 0; index < 10; index++)
                // {
                //     Console.WriteLine(arr[index]);
                // }

                Cadastrar("");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Ops, algo deu errado" + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("O texto não pode ser nulo ou vazio" + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            catch (MinhaExecption ex)
            {
                Console.WriteLine("O texto não pode ser nulo ou vazio" + ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.QuandoaAconteceu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ops, algo deu errado" + ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            finally
            {
                Console.WriteLine("Chegou ao Fim");
            }

        }

        static void Cadastrar(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new MinhaExecption(DateTime.Now);
        }

        public class MinhaExecption : Exception
        {
            public MinhaExecption(DateTime date)
            {
                QuandoaAconteceu = date;
            }

            public DateTime QuandoaAconteceu { get; set; }
        }
    }
}