using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Exlcuir uma Tag");
            Console.WriteLine("-----------------");

            Console.WriteLine("Id da TAG que deseja exlcuir: ");
            var id = Console.ReadLine();

            if (id == null)
            {
                Console.WriteLine("Insira os valroes corretamente");
                return;
            }
            Update(int.Parse(id));
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag excluida com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}