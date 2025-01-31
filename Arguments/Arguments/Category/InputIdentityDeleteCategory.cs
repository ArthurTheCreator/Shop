using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentityDeleteCategory(long id)
{
    public long Id { get; private set; } = id;
}