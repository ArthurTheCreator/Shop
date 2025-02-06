using System.Text.Json.Serialization;

namespace Shop.Web.Models;

[method: JsonConstructor]
public class InputIdentiityDeleteProduct(long id)
{
    public long Id { get; private set; } = id;
}