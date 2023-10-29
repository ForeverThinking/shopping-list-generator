using Microsoft.EntityFrameworkCore;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;

namespace ShoppingListGenerator.Services;

public interface IShoppingListGeneratorServices
{
    public Task<IEnumerable<Recipe>> GetAllRecipesAsync();
    public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
}

public class ShoppingListGeneratorServices : IShoppingListGeneratorServices
{
    private readonly ShoppingListContext _context;
    public ShoppingListGeneratorServices(ShoppingListContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
    {
        var recipes = await _context.Recipes.ToListAsync();

        return recipes;
    }

    public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
    {
        var ingredients = await _context.Ingredients.ToListAsync();

        return ingredients;
    }
}