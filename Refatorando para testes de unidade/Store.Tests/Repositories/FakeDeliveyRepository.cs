using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories
{
    public class FAkeDeliveryRepositories : IDeliveryFreeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}