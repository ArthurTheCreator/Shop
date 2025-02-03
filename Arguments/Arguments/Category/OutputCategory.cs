using Arguments.Arguments.Base.DTO;
using Arguments.Arguments.Product;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class OutputCategory(long id, string? name, string? description) : BaseOutuput<OutputCategory>
{
    public long Id { get; private set; } = id;
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
    public List<OutputProduct> listProduct { get; private set; }
}