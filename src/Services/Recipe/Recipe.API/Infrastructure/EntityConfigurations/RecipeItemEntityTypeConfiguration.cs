using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.API.Model;

namespace Recipe.API.Infrastructure.EntityConfigurations
{
    public class RecipeItemEntityTypeConfiguration : IEntityTypeConfiguration<RecipeItem>
    {
        public void Configure(EntityTypeBuilder<RecipeItem> builder)
        {
            builder.ToTable("recipes");

            builder.Property(ci => ci.Id)
                .UseHiLo("recipe_hilo")
                .IsRequired();

            builder.Property(ci => ci.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ci => ci.Description)
                .IsRequired(false);

            builder.Property(ci => ci.Img)
                .IsRequired(false);

            builder.Property(ci => ci.Meal)
                .IsRequired(false);

            builder.Property(ci => ci.Time)
                .IsRequired(false);

            builder.Property(ci => ci.Rating)
                .IsRequired(false);

            builder.Property(ci => ci.Order)
                .IsRequired(false);

            builder.Property(ci => ci.CreatedAt)
                .IsRequired(false);

            builder.Property(ci => ci.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(ci => ci.Author)
                .WithMany()
                .HasForeignKey(ci => ci.AuthorId);

            builder.HasOne(ci => ci.Tags)
                .WithMany()
                .HasForeignKey(ci => ci.TagId);
        }
    }
}