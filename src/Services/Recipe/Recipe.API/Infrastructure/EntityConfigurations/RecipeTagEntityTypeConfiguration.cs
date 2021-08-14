using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.API.Model;

namespace Recipe.API.Infrastructure.EntityConfigurations
{
    public class RecipeTagEntityTypeConfiguration : IEntityTypeConfiguration<RecipeTag>
    {
        public void Configure(EntityTypeBuilder<RecipeTag> builder)
        {
            builder.ToTable("recipe_tags");
            
            builder.Property(ci => ci.Id)
                .UseHiLo("recipe_tag_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.Value)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}