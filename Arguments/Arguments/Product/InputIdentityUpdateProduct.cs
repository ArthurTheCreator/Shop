using Arguments.Arguments.Base.DTO;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class InputIdentityUpdateProduct(long id, InputUpdateProduct inputUpdateProduct) : BaseInputIdentityUpdate<InputIdentityUpdateProduct>
{
    public long Id { get; private set; } = id;
    public InputUpdateProduct InputUpdateProduct { get; private set; } = inputUpdateProduct;
}