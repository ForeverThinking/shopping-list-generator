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
    public IActionResult GetRecipes()
    {
        var recipes = _shoppingListGeneratorServices.GetAllRecipes();
        
        return View(recipes);
    }
}