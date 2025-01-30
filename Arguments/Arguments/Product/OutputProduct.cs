using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class OutputProduct(long id, string? name, string? description, decimal price, long stock, long categoryId, string? imageURL)
{
    public long Id { get; private set; } = id;
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
    public decimal Price { get; private set; } = price;
    public long Stock { get; private set; } = stock;
    public long CategoryId { get; private set; } = categoryId;
    public string? ImageURL { get; private set; } = imageURL;
}