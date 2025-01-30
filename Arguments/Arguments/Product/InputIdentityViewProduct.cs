using Arguments.Arguments.Base;
using System.Text.Json.Serialization;

namespace Arguments.Arguments.Product;

[method: JsonConstructor]
public class InputIdentityViewProduct(long id) : IHashId
{
    public long Id { get; private set; } = id;
}