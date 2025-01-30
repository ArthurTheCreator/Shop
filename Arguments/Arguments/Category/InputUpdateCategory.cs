using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputUpdateCategory(string? name, string? description)
{
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
}