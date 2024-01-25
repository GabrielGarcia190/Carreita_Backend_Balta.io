namespace Parte1.Models;

public class Product
{
    public Product(string id, decimal price, string name)
    {
        Id = id;
        Price = price;
        Name = name;
    }

    public string Id { get; private set; }
    public decimal Price { get; private set; }
    public string Name { get; private set; }
}