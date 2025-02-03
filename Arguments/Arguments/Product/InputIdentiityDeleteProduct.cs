using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class InputIdentiityDeleteProduct(long id) : BaseInputIdentityDelete<InputIdentiityDeleteProduct>
{
    public long Id { get; private set; } = id;
}