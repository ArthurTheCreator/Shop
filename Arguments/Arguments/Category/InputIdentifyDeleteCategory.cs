using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentifyDeleteCategory(long id)
{
    public long Id { get; private set; } = id;
}