using Dapper;
using Microsoft.Data.SqlClient;
using Parte1.Models;
using Parte1.Repositories.Contracts;

namespace Parte1.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly SqlConnection _sqlConnection;

    public PromoCodeRepository(SqlConnection sqlConnection) => _sqlConnection = sqlConnection;

    public async Task<PromoCode?> GetByCodeAsync(string promoCode)
    {
        var query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";

        return await _sqlConnection.QueryFirstOrDefaultAsync<PromoCode>(query, new { code = promoCode });
        
    }
}