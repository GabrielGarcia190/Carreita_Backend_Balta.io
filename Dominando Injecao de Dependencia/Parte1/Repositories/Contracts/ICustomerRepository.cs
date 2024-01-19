using Parte1.Models;

namespace Parte1.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(string customerId);
    }
}