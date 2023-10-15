using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public IList<Recipe> GetAllRecipes();
    public IList<Ingredient> GetAllIngredients();
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

    public IList<Ingredient> GetAllIngredients()
    {
        // Change to database implementation
        var ingredients = new List<Ingredient>
        {
            new() { IngredientId = 1, Name = "Red Onion" },
            new() { IngredientId = 2, Name = "Olives" }
        };

        return ingredients;
    }
}