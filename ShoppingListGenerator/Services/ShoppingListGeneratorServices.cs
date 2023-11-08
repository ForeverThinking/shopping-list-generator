using Microsoft.EntityFrameworkCore;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public Task<IEnumerable<RecipeModel>> GetAllRecipesAsync();
    public Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync();
    public Task<Dictionary<string, int>> GetShoppingListAsync(IEnumerable<int> recipeIds);
    public Task<List<MenuSelectionViewModel>> GetRecipesForMenuSelectionAsync();
}

public class ShoppingListGeneratorServices : IShoppingListGeneratorServices
{
    private readonly ShoppingListContext _context;
    public ShoppingListGeneratorServices(ShoppingListContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<RecipeModel>> GetAllRecipesAsync() 
        => await _context.Recipes.ToListAsync();

    public async Task<IEnumerable<IngredientModel>> GetAllIngredientsAsync() 
        => await _context.Ingredients.ToListAsync();

    public async Task<Dictionary<string, int>> GetShoppingListAsync(IEnumerable<int> recipeIds)
    {
        var recipeIngredients = await _context.RecipeIngredients
            .Where(ri => recipeIds.Contains(ri.RecipeId))
            .Include(ri => ri.Ingredient)
            .ToListAsync();

        return recipeIngredients.ToDictionary(item => item.Ingredient!.Name!, item => item.Quantity);
    }

    public async Task<List<MenuSelectionViewModel>> GetRecipesForMenuSelectionAsync()
    {
        var recipes = await GetAllRecipesAsync();

        return recipes.Select(recipe => new MenuSelectionViewModel 
            { RecipeId = recipe.Id, RecipeName = recipe.Name, IsSelected = false, }).ToList();
    }
}