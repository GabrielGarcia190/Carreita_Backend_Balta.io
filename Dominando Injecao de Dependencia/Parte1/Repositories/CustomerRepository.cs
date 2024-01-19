using Dapper;
using Microsoft.Data.SqlClient;
using Parte1.Models;
using Parte1.Repositories.Contracts;

namespace Parte1.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly SqlConnection _connection;
    public CustomerRepository(SqlConnection connection) => _connection = connection;

    public async Task<Customer?> GetByIdAsync(string customerId)
    {
        const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
        return await _connection
        .QueryFirstOrDefaultAsync<Customer>(query, new
        {
            id = customerId
        }, null);
    }
}