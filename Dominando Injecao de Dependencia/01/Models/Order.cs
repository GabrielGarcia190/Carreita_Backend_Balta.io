namespace Parte1.Models;

public class Order
{
    public Order(decimal deliveryFee, decimal discount, List<Product> products)
    {
        Code = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
        Date = DateTime.Now;
        DeliveryFee = deliveryFee;
        Discount = discount;
        Products = new List<Product>(products);
    }

    public string Code { get; private set; }
    public DateTime Date { get; private set; }
    public decimal DeliveryFee { get; private set; }
    public decimal Discount { get; private set; }
    public List<Product> Products { get; private set; }
    public decimal SubTotal => Products.Sum(x => x.Price);
    public decimal Total => SubTotal + DeliveryFee - Discount;
}