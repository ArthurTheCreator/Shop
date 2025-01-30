using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Persistence.Entity;

public class Category : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<Product> listProduct { get; set; }

    public Category() { }

    public Category(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
}