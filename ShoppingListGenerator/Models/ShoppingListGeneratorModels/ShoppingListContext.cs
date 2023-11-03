using Microsoft.EntityFrameworkCore;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class ShoppingListContext : DbContext
{
    public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
        : base(options)
    {
    }

    public DbSet<RecipeModel> Recipes => Set<RecipeModel>();
    public DbSet<IngredientModel> Ingredients => Set<IngredientModel>();
    public DbSet<RecipeIngredientModel> RecipeIngredients => Set<RecipeIngredientModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeIngredientModel>()
            .HasKey(k => new { k.RecipeId, k.IngredientId });

        modelBuilder.Entity<RecipeIngredientModel>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredient)
            .HasForeignKey(ri => ri.RecipeId);

        modelBuilder.Entity<RecipeIngredientModel>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredient)
            .HasForeignKey(ri => ri.IngredientId);

        base.OnModelCreating(modelBuilder);
    }
}