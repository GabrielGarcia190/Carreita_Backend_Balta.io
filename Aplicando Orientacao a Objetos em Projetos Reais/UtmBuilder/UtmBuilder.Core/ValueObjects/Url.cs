using System.Text.RegularExpressions;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObjects
{
    private const string UrlRegexPattern = @"/^(?:([A-Za-z]+):)?(\/{0,3})([0-9.\-A-Za-z]+)(?::(\d+))?(?:\/([^?#]*))?(?:\?([^#]*))?(?:#(.*))?$/";

    public Url(string address)
    {
        Address = address;
        InvalidUrlException.ThrowIfInvalid(address);
    }

    /// <summary>
    /// Adddres of URL (WebsiteLink)
    /// </summary>
    public string Address { get; }
}