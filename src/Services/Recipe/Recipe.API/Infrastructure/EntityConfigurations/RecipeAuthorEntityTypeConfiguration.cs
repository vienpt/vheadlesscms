using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.API.Model;

namespace Recipe.API.Infrastructure.EntityConfigurations
{
    public class RecipeAuthorEntityTypeConfiguration : IEntityTypeConfiguration<RecipeAuthor>
    {
        public void Configure(EntityTypeBuilder<RecipeAuthor> builder)
        {
            builder.ToTable("recipe_authors");

            builder.Property(ci => ci.Id)
                .UseHiLo("recipe_author_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.Image)
                .IsRequired(false);
        }
    }
}