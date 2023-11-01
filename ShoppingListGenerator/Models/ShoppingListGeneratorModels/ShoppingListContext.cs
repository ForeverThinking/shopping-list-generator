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
    public DbSet<MeasurementModel> Measurements => Set<MeasurementModel>();
    public DbSet<RecipeIngredientModel> RecipeIngredients => Set<RecipeIngredientModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeIngredientModel>()
            .HasKey(k => new { k.RecipeId, k.IngredientId, k.MeasurementId });

        base.OnModelCreating(modelBuilder);
    }
}