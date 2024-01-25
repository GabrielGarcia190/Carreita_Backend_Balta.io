namespace Parte1.Models;

public class PromoCode
{
    public PromoCode(DateTime? expireDate, decimal? value, string? code)
    {
        ExpireDate = expireDate;
        Value = value;
        Code = code;
    }

    public DateTime? ExpireDate { get; private set; }
    public decimal? Value { get; private set; }
    public string? Code { get; private set; }
}