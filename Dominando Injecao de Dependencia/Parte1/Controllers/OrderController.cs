using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Parte1.Models;
using Parte1.Repositories.Contracts;
using Parte1.Services.Contracts;
using RestSharp;

namespace Parte1.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromoCodeRepository _promoCodeRepository;
    public OrderController(ICustomerRepository customerRepository, IDeliveryFeeService deliveryFeeService, IPromoCodeRepository promoCodeRepository)
    {
        _customerRepository = customerRepository;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepository = promoCodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);


        if (customer == null)
            return NotFound(new
            {
                Message = "Cliente não encontrado"
            });

        var deliveryFee = await _deliveryFeeService.GetDeliveryFeeAsync(zipCode);
        var cupom = await _promoCodeRepository.GetByCodeAsync(promoCode);
        var discount = cupom?.Value ?? 0;
        var order = new Order(deliveryFee, discount, new List<Product>());

        return Ok($"Pedido {order.Code} gerado com sucesso");
    }
}