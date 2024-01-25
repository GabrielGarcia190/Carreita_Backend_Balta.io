using Parte1.Models;

namespace Parte1.Repositories.Contracts
{
    public interface IPromoCodeRepository
    {
        Task<PromoCode?> GetByCodeAsync(string promoCode);
    }
}