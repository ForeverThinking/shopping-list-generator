using Microsoft.EntityFrameworkCore;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class ShoppingListContext : DbContext
{
    public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeIngredient>().HasKey(k => new { k.RecipeId, k.IngredientId });

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(x => x.Recipe)
            .WithMany(x => x.RecipeIngredients)
            .HasForeignKey(x => x.RecipeId);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(x => x.Ingredient)
            .WithMany(x => x.RecipeIngredients)
            .HasForeignKey(x => x.IngredientId);

        base.OnModelCreating(modelBuilder);
    }
}