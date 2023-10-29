using Microsoft.AspNetCore.Mvc;
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
}