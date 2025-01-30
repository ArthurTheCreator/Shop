using Infrastructure.Persistence.Entity.Base;

namespace Infrastructure.Persistence.Entity;

public class Product : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public long CategoryId { get; set; }
    public string? ImageURL { get; set; }

    public Category Category { get; set; }

    public Product() { }

    public Product(string? name, string? description, decimal price, long stock, long categoryId, string? imageURL)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        ImageURL = imageURL;
    }
}
