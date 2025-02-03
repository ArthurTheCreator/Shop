using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputUpdateCategory(string? name, string? description) : BaseInputUpdate<InputUpdateCategory>
{
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
}