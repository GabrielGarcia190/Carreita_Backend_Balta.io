namespace Parte1.Services.Contracts
{
    public interface IDeliveryFeeService
    {
        Task<decimal> GetDeliveryFeeAsync(string zipCode);
    }
}