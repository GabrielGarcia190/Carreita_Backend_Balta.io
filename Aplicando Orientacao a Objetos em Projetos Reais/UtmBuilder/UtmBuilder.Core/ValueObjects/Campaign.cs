using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObjects
{
    public Campaign(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;

        InvalidCampaignException.ThrowIfNull(source, "Source is invalid");
        InvalidCampaignException.ThrowIfNull(medium, "Medium is invalid");
        InvalidCampaignException.ThrowIfNull(name, "name is invalid");
    }

    public string Source { get; }
    public string Medium { get; }
    public string Name { get; }
    public string? Id { get; }
    public string? Term { get; }
    public string? Content { get; }
}