using Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Mapping
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(c => c.Id);

            builder.Property(i => i.Name).HasColumnName("nome");
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.Name).HasMaxLength(40);

            builder.Property(i => i.Description).HasColumnName("descrição");
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(100);
        }
    }
}