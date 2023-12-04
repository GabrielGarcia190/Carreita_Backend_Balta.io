using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("-----------------");

            Console.WriteLine("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            if (name == null || slug == null)
            {
                Console.WriteLine("Insira os valroes corretamente");
                return;
            }
            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}