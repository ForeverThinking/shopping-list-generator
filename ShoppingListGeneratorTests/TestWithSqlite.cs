using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGeneratorTests;

public class TestWithSqlite : IDisposable
{
    private const string ConnectionString = "Data Source=:memory:";
    private readonly SqliteConnection _connection;

    protected readonly ShoppingListContext Context;

    protected TestWithSqlite()
    {
        _connection = new SqliteConnection(ConnectionString);
        _connection.Open();
        var options = new DbContextOptionsBuilder<ShoppingListContext>()
            .UseSqlite(_connection)
            .Options;
        Context = new ShoppingListContext(options);
        Context.Database.EnsureCreated();
    }
    
    public void Dispose()
    {
        _connection.Close();
    }

    protected async Task SeedRecipes()
    {
        Context.Recipes.Add(new RecipeModel { Id = 1, Name = "Greek Salad" });
        Context.Recipes.Add(new RecipeModel { Id = 2, Name = "Chicken Adobo" });
        
        await Context.SaveChangesAsync();
    }

    protected async Task SeedIngredients()
    {
        Context.Ingredients.Add(new IngredientModel { Id = 1, Name = "Red Onion" });
        Context.Ingredients.Add(new IngredientModel { Id = 2, Name = "Olives" });
        
        await Context.SaveChangesAsync();
    }
}