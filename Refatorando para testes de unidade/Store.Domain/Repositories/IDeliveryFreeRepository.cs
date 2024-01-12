namespace Store.Domain.Repositories.Interfaces
{
    public interface IDeliveryFreeRepository
    {
        decimal Get(string zipCode);
    }
}