using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection = new SqlConnection();

        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }


    }
}