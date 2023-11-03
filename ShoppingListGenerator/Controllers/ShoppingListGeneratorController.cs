using Microsoft.AspNetCore.Mvc;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;

namespace ShoppingListGenerator.Controllers;

public class ShoppingListGeneratorController : Controller
{
    private readonly IShoppingListGeneratorServices _shoppingListGeneratorServices;

    public ShoppingListGeneratorController(IShoppingListGeneratorServices shoppingListGeneratorServices)
    {
        _shoppingListGeneratorServices = shoppingListGeneratorServices;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRecipesAsync()
    {
        var recipes = await _shoppingListGeneratorServices.GetAllRecipesAsync();
        
        return View(recipes);
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredientsAsync()
    {
        var ingredients = await _shoppingListGeneratorServices.GetAllIngredientsAsync();
        
        return View(ingredients);
    }

    [HttpGet]
    public async Task<IActionResult> GetShoppingList()
    {
        // Test for now, will update with POST later
        var test = new List<RecipeModel>
        {
            new() { Id = 1 }
        };

        var shoppingList = await _shoppingListGeneratorServices.GetShoppingListAsync(test);

        return View(shoppingList);
    }
}