using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Parte1.Repositories;
using Parte1.Repositories.Contracts;
using Parte1.Services.Contracts;

namespace Parte1.Extensions;

public static class DependenciesExtension
{
    public static void AddSqlConnection(
        this IServiceCollection services, 
        string connectionString)
    {
        services.AddScoped<SqlConnection>(x 
            => new SqlConnection(connectionString));
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.TryAddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }
}