using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public IList<Recipe> GetAllRecipes();
}

public class ShoppingListGeneratorServices : IShoppingListGeneratorServices
{
    public IList<Recipe> GetAllRecipes()
    {
        // Change to database implementation
        var recipes = new List<Recipe>
        {
            new() { Id = 1, Name = "Greek Salad" },
            new() { Id = 2, Name = "Chicken Adobo" }
        };

        return recipes;
    }
}