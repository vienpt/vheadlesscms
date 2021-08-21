using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Recipe.API.Infrastructure.EntityConfigurations;
using Recipe.API.Model;

namespace Recipe.API.Infrastructure
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base (options)
        {
        }
        
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<RecipeAuthor> RecipeAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeTagEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeAuthorEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}