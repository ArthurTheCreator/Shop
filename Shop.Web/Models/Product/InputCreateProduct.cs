﻿using System.Text.Json.Serialization;

namespace Shop.Web.Models;

[method: JsonConstructor]
public class InputCreateProduct(string? name, string? description, decimal price, long stock, long categoryId, string? imageURL)
{
    public string? Name { get; private set; } = name;
    public string? Description { get; private set; } = description;
    public decimal Price { get; private set; } = price;
    public long Stock { get; private set; } = stock;
    public long CategoryId { get; private set; } = categoryId;
    public string? ImageURL { get; private set; } = imageURL;
}