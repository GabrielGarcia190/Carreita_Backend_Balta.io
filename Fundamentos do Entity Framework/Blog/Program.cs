using Blog.Data;
using Blog.Models;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                //CREATE
                // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
                // context.Tags.Add(tag);
                // context.SaveChanges();

                //UPDATE
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
                // tag.Name = ".NET";
                // tag.Slug = "dotnet";
                // context.Update(tag);
                // context.SaveChanges();

                //DELETE
                // var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
                // context.Remove(tag);
                // context.SaveChanges();

                var tags = context.Tags.ToList();

                foreach (var tag in tags)
                {
                    Console.WriteLine(tag.Name);
                }
            }
        }
    }
}