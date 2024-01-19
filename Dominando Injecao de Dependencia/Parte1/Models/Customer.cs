namespace Parte1.Models;

public class Customer
{
    public Customer(string? id, string? email, string? name)
    {
        Id = id;
        Email = email;
        Name = name;
    }

    public string? Id { get; private set; }
    public string? Email { get; private set; }
    public string? Name { get; private set; }
}