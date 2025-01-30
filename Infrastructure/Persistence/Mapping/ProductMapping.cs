using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(i => i.Category).WithMany(i => i.listProduct).HasForeignKey(i => i.CategoryId).HasConstraintName("fkey_produto_id_categoria");

        builder.ToTable("produto");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name).HasColumnName("name");
        builder.Property(i => i.Name).IsRequired();
        builder.Property(i => i.Name).HasMaxLength(40);

        builder.Property(i => i.Description).HasColumnName("descrição");
        builder.Property(i => i.Description).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(100);

        builder.Property(i => i.Price).HasColumnName("preço");
        builder.Property(i => i.Price).IsRequired();

        builder.Property(i => i.Stock).HasColumnName("estoque");
        builder.Property(i => i.Stock).IsRequired();

        builder.Property(i => i.CategoryId).HasColumnName("id_categoria");
        builder.Property(i => i.CategoryId).IsRequired();

        builder.Property(i => i.ImageURL).HasColumnName("imagemUrl");
        builder.Property(i => i.ImageURL).IsRequired();

    }
}
