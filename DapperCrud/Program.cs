using Dapper;
using Microsoft.Data.SqlClient;



const string connectionString =
    "Server=localhost,1433;Database=DapperCrud;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
await using (var connection = new SqlConnection(connectionString))
{
    var id = await connection.ExecuteScalarAsync<int>("INSERT INTO [Category] VALUES(@title, @slug, @description);SELECT CAST(scope_identity() AS INT)",
        new
        {
            title = "Title",
            slug = "backend",
            description = "Aprenda tudo sobre backend nesta carreira completa."
        });

    Console.WriteLine(id);
}