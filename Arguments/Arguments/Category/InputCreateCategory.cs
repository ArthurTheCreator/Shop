using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputCreateCategory(string? name, string? description) : BaseInputCreate<InputCreateCategory>
{
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
}
