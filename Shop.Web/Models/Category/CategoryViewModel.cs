namespace Shop.Web.Models;

public class CategoryViewModel(long id, string? name, string? description)
{
    public long Id { get; private set; } = id;
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
}
