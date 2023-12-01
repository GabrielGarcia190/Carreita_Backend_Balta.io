using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            const string connectionString = "Data Source=NomeDoServidor\\SQL2022 ;Initial Catalog=NomeDoBanco;User ID=sa; pwd=SenhaDoSQL;Encrypt=False;";

            using (var connection = new SqlConnection(connectionString))
            {
                // UpdateCategory(connection);
                // CreateManyCategory(connection);
                // DeleteCategoory(connection);
                // ListarCategorias(connection);
                // CreateCategory(connection);
                // ExecuteEscalar(connection);
                // ReadView(connection);
                // OneToOne(connection);
                // OneToMany(connection);
                // QueyMultiple(connection);
                SelectIN(connection);
            }
            #region Coméntário de como Fazer com ADO.NET
            //COMO FAZER COM ADO.NET
            // using (var connection = new SqlConnection(connectionString))
            // {
            //     connection.Open();

            //     using (var command = new SqlCommand())
            //     {
            //         command.Connection = connection;
            //         command.CommandType = System.Data.CommandType.Text;
            //         command.CommandText = "SELECT id, Title FROM Category";

            //         var reader = command.ExecuteReader();

            //         while (reader.Read())
            //         {
            //             Console.WriteLine($"{reader.GetGuid(0)} --- {reader.GetString(1)}");
            //         }
            //     }
            // }
            #endregion

        }
        static void ListarCategorias(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT Id, Title FROM Category");

            foreach (var item in categories)
            {
                Console.WriteLine($"Id: {item.Id} -- Nome: {item.Title}");
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon.com";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                 Category 
            VALUES (
                @Id,
                @Title, 
                @Url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            const string updateQuery = "UPDATE Category SET Title = @Title WHERE Id = @Id";

            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("2801d374-e097-42c2-b25c-ee65d1ccd2d2"),
                title = "Amazon Cloud 2.0 Prime Full"
            });

            Console.WriteLine($"{rows} linhas alterada");
        }

        static void DeleteCategoory(SqlConnection connection)
        {
            const string deleteQuerty = "DELETE Category WHERE id = @Id";

            var rows = connection.Execute(deleteQuerty, new
            {
                Id = new Guid("2801d374-e097-42c2-b25c-ee65d1ccd2d2")
            });

            Console.WriteLine($"{rows} inhas deletadas");

        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon.com";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category1 = new Category();
            category1.Id = Guid.NewGuid();
            category1.Title = "Amazon Normal";
            category1.Url = "amazon.com";
            category1.Description = "Categoria destinada a serviços do AWS";
            category1.Order = 8;
            category1.Summary = "AWS Cloud";
            category1.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Amazon AWS Prime Full Mega Blaster";
            category2.Url = "amazon.com";
            category2.Description = "Categoria destinada a serviços do AWS";
            category2.Order = 8;
            category2.Summary = "AWS Cloud";
            category2.Featured = false;

            var insertSql = @"INSERT INTO
                 Category 
            VALUES (
                @Id,
                @Title, 
                @Url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured)";

            var rows = connection.Execute(insertSql, new[]{
            new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
           new {
                category1.Id,
                category1.Title,
                category1.Url,
                category1.Summary,
                category1.Order,
                category1.Description,
                category1.Featured
            },
            new {
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured
            }
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }

        static void ExecuteProcedure(SqlConnection connection)
        {
            const string sql = "[spDeleteStudent]";

            var pars = new { StudentId = "" };
            var affectdRows = connection.Execute(sql, pars, commandType: System.Data.CommandType.StoredProcedure);

            Console.WriteLine($"{affectdRows} linhas afetadas");
        }

        static void ExecuteEscalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "amazon.com";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                 Category 
                 OUTPUT inserted.Id
            VALUES (
                NEWID(),
                @Title, 
                @Url, 
                @Summary, 
                @Order, 
                @Description, 
                @Featured)";

            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"Cadastrado com sucesso no id {id}");
        }

        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            var courses = connection.Query(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"Id: {item.Id} -- Nome: {item.Title}");
            }
        }

        static void OneToOne(SqlConnection connection)
        {
            var sql = @"
            SELECT
                *
            FROM
                [CareerItem]
            INNER JOIN
                [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            var items = connection.Query<CarrerItem, Course, CarrerItem>(sql,
            (carrerItem, course) =>
            {
                carrerItem.Course = course;
                return carrerItem;
            }, splitOn: "Id");

            foreach (var item in items)
            {
                Console.WriteLine(item.Course.Title);
            }
        }

        static void OneToMany(SqlConnection connection)
        {
            var sql = @"
           SELECT 
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[Title]
            FROM 
                 [Career] 
            INNER JOIN 
                [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
            ORDER BY
                [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CarrerItem, Career>(sql,
            (career, item) =>
            {
                var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                if (car == null)
                {
                    car = career;
                    car.Items.Add(item);
                    careers.Add(car);
                }
                else
                {
                    car.Items.Add(item);
                }
                return career;
            }, splitOn: "CareerId");

            foreach (var career in careers)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($"{career.Title}");
                }
            }
        }

        static void QueyMultiple(SqlConnection connection)
        {
            var query = "SELECT * FROM Category; SELECT * FROM Course";

            using (var multi = connection.QueryMultiple(query))
            {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories)
                {
                    Console.WriteLine("Categorias: {0}", item.Title);
                }

                foreach (var item in courses)
                {
                    Console.WriteLine("Cusos: {0}", item.Title);
                }
            }
        }

        static void SelectIN(SqlConnection connection)
        {
            var query = @"SELECT * FROM Career WHERE Id IN @Id";

            var items = connection.Query<Career>(query, new
            {
                Id = new[]{
                "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
                "e6730d1c-6870-4df3-ae68-438624e04c72"
                }
            });

            foreach (var item in items)
            {
                Console.WriteLine("Carreira: {0}", item.Title);
            }
        }

        static void Like(SqlConnection connection)
        {
            var term = "api";
            var query = @"SELECT * FROM Courses WHERE Title LIKE @exp";

            var items = connection.Query<Career>(query, new
            {
                exp = $"%{term}"
            });

            foreach (var item in items)
            {
                Console.WriteLine("Carreira: {0}", item.Title);
            }
        }
    }

}