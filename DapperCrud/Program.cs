using Dapper;
using Microsoft.Data.SqlClient;



Console.WriteLine("=====================CRUD DAPPER ============================");
Console.WriteLine("SELECIONE QUAL OPERAÇÃO DESEJA FAZER");
Console.WriteLine("1: CADASTRAR CURSOS");
Console.WriteLine("2: LISTAR CURSOS");
Console.WriteLine("3: EDITAR CURSOS");
Console.WriteLine("4: ELINIMAR CURSO");
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

    default:
        Console.WriteLine("Escolha uma opção válida");
        break;
}


