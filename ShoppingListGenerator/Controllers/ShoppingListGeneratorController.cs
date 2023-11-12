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
    public async Task<IActionResult> Recipes()
    {
        var recipes = await _shoppingListGeneratorServices.GetAllRecipesAsync();
        
        return View(recipes);
    }

    [HttpGet]
    public async Task<IActionResult> Ingredients()
    {
        var ingredients = await _shoppingListGeneratorServices.GetAllIngredientsAsync();
        
        return View(ingredients);
    }

    [HttpGet]
    public async Task<IActionResult> MenuSelection()
    {
        var menuItems = await _shoppingListGeneratorServices.GetRecipesForMenuSelectionAsync();

        return View(menuItems);
    }

    [HttpPost]
    public async Task<IActionResult> ShoppingList(List<MenuSelectionViewModel> menuSelection)
    {
        var ingredientIds = menuSelection.Where(ms => ms.IsSelected)
            .Select(ms => ms.RecipeId);

        var ingredients = await _shoppingListGeneratorServices.GetShoppingListAsync(ingredientIds);
        
        return View(ingredients);
    }
}