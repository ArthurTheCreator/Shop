using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class InputIdentiityDeleteProduct(long id)
{
    public long Id { get; private set; } = id;
}