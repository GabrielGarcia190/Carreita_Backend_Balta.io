
using RestSharp;

namespace Parte1.Services.Contracts;

public class DeliveryFeeService : IDeliveryFeeService
{
    public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
    {
        var cliente = new RestClient("https://consultafrete.io/cep/");

        var request = new RestRequest()
            .AddJsonBody(new
            {
                ZipCode = zipCode
            });

        var response = await cliente.PostAsync<decimal>(request);

        return response == 0 ? 5 : response;
    }
}