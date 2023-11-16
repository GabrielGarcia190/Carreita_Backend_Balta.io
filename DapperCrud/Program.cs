using Dapper;
using Microsoft.Data.SqlClient;



Console.WriteLine("=====================CRUD DAPPER ============================");
Console.WriteLine("SELECIONE QUAL OPERAÇÃO DESEJA FAZER");
Console.WriteLine("1: CADASTRAR CURSOS");
Console.WriteLine("2: LISTAR TODOS OS CURSOS");
Console.WriteLine("3: PROCURAR CURSO POR NOME");
Console.WriteLine("4: EDITAR CURSOS");
Console.WriteLine("5: ELINIMAR CURSO");
var escolha = Console.ReadLine();

switch (escolha)
{
    case "1":
        Console.WriteLine("Insira o titulo do Curso: ");
        var _titulo = Console.ReadLine();

        Console.WriteLine("Insira a categoria: ");
        var _categoria = Console.ReadLine();

        Console.WriteLine("Insira a descrição: ");
        var _descricao = Console.ReadLine();

        try
        {
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {
                var id = await connection.ExecuteScalarAsync<int>("INSERT INTO Category VALUES(@title, @slug, @description);SELECT CAST(scope_identity() AS INT)",
                    new
                    {
                        title = _titulo,
                        slug = _categoria,
                        description = _descricao
                    });

                Console.WriteLine("Dados gravados com sucesso");
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

        break;

    case "2":
        try
        {
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {

                var categories = await connection.QueryAsync("SELECT [Id], [Title], [Slug], [Description] FROM [Category]");
                if (categories == null)
                {
                    Console.WriteLine("Nenhum resultado encontrado");
                    break;
                }
                foreach (var category in categories)
                    Console.WriteLine($"ID: {category.Id} \nTitulo do Curso: {category.Title} \n \n ");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        break;

    case "3":
        try
        {
            Console.WriteLine("Insira o titulo do Curso: ");
            var _nomeCurso = Console.ReadLine();

            Console.WriteLine();
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {
                var categories = await connection.QueryFirstOrDefaultAsync("SELECT [Id], [Title], [Slug], [Description] FROM [Category] WHERE [Title]=@Title", new { Title = _nomeCurso });
                if (categories == null)
                {
                    System.Console.WriteLine("Nenhum resultado encontrado");
                    break;
                }

                Console.WriteLine("Titulo do Curso" + categories.Title);
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
        break;

    case "4":
        Console.WriteLine("Insira o código do Item que será editado");
        var _idCurso = Console.ReadLine();

        Console.WriteLine("Insira o código do nova titulo do Curso");
        var _tituloCurso = Console.ReadLine();

        Console.WriteLine("Insira o código do nova categoria do Curso");
        var _categoriaCurso = Console.ReadLine();

        Console.WriteLine("Insira o código a nova descrição do Curso");
        var _descricaoCurso = Console.ReadLine();


        try
        {
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {
                await connection.ExecuteAsync(
                 "UPDATE [Category] SET [Title]=@title, [Slug]=@slug, [Description]=@description WHERE [Id]=@id",
                 new { id = _idCurso, title = _tituloCurso, slug = _categoriaCurso, description = _descricaoCurso });
            }

            Console.WriteLine("Dados salvos com sucesso");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        break;

    case "5":
        Console.WriteLine("Insira o código do Item que será apagado");
        var _id = Console.ReadLine();

        try
        {
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {
                await connection.ExecuteAsync(
                    "DELETE FROM [Category] WHERE [Id]=@id",
                    new { id = _id });
            }

            Console.WriteLine("Curso removido com sucesso");
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        break;
    default:
        Console.WriteLine("Escolha uma opção válida");
        break;
}

Console.WriteLine("=====================FIM============================");
