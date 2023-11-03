using Microsoft.EntityFrameworkCore;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public Task<IEnumerable<RecipeModel>> GetAllRecipesAsync();
    public Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync();
    public Task<Dictionary<string, int>> GetShoppingListAsync(IEnumerable<RecipeModel> recipes);
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

    public async Task<Dictionary<string, int>> GetShoppingListAsync(IEnumerable<RecipeModel> recipes)
    {
        var recipeIds = recipes.Select(r => r.Id).ToArray();

        var recipeIngredients = await _context.RecipeIngredients
            .Where(ri => recipeIds.Contains(ri.RecipeId))
            .Include(ri => ri.Ingredient)
            .Include(ri => ri.Recipe)
            .ToListAsync();

        return recipeIngredients.ToDictionary(item => item.Ingredient!.Name!, item => item.Quantity);
    }
}