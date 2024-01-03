using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighbodhood, string city, string country, string state, string zipCode)
        {
            Street = street;
            Number = number;
            Neighbodhood = neighbodhood;
            City = city;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighbodhood { get; set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }  
        public string ZipCode { get; set; }
    }
}