using Microsoft.EntityFrameworkCore;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public Task<IEnumerable<RecipeModel>> GetAllRecipesAsync();
    public Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync();
}

public class ShoppingListGeneratorServices : IShoppingListGeneratorServices
{
    private readonly ShoppingListContext _context;
    public ShoppingListGeneratorServices(ShoppingListContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<RecipeModel>> GetAllRecipesAsync()
    {
        var recipes = await _context.Recipes.ToListAsync();

        return recipes;
    }

    public async Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync()
    {
        var ingredients = await _context.Ingredients.ToListAsync();

        return ingredients;
    }
}