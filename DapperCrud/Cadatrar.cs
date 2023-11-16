using Dapper;
using Microsoft.Data.SqlClient;

class Cadastrar
{

    public static async void CadastrarCurso(string titulo, string categoria, string descricao)
    {

        try
        {
            await using (var connection = new SqlConnection(connectionString._connectionString))
            {
                var id = await connection.ExecuteScalarAsync<int>("INSERT INTO Category VALUES(@title, @slug, @description);SELECT CAST(scope_identity() AS INT)",
                    new
                    {
                        title = titulo,
                        slug = categoria,
                        description = descricao
                    });
                Console.WriteLine("Dados gravados com sucesso");
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

}