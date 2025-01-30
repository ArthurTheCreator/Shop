using System.Text.Json.Serialization;

namespace Arguments.Arguments.Category;

[method: JsonConstructor]
public class InputIdentifyUpdateCategory(long id, InputUpdateCategory inputUpdateCategory)
{
    public long Id { get; private set; } = id;
    public InputUpdateCategory InputUpdateCategory { get; private set; } = inputUpdateCategory;
}