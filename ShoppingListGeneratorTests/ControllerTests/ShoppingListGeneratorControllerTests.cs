using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;
using ShoppingListGenerator.Controllers;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;

namespace ShoppingListGeneratorTests.ControllerTests;

public class ShoppingListGeneratorControllerTests : Controller
{
    private readonly IShoppingListGeneratorServices _shoppingListService = Substitute.For<IShoppingListGeneratorServices>();
    private readonly ShoppingListGeneratorController _underTest;

    public ShoppingListGeneratorControllerTests()
    {
        _underTest = new ShoppingListGeneratorController(_shoppingListService);
    }
    
    [Fact]
    public async Task GetRecipes_Called_ReturnsValidView()
    {
        // Arrange
        var expectedResult = new List<RecipeModel>()
        {
            new() { Id = 1, Name = "Greek Salad" },
            new() { Id = 2, Name = "Chicken Adobo" }
        };
        
        _shoppingListService.GetAllRecipesAsync().Returns(expectedResult);
        
        // Act
        var result = await _underTest.Recipes();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IList<RecipeModel>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task GetIngredients_Called_ReturnsValidView()
    {
        // Arrange
        var expectedResult = new List<IngredientModel>()
        {
            new() { Id = 1, Name = "Red Onion" },
            new() { Id = 2, Name = "Olives" }
        };
        
        _shoppingListService.GetAllIngredientsAsync().Returns(expectedResult);
        
        // Act
        var result = await _underTest.Ingredients();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IList<IngredientModel>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task GetMenuSelection_Called_ReturnsValidView()
    {
        // Arrange
        var expectedResult = new List<MenuSelectionViewModel>()
        {
            new() { RecipeId = 1, RecipeName = "Test1", IsSelected = true },
            new() { RecipeId = 1, RecipeName = "Test2", IsSelected = false }
        };
        
        _shoppingListService.GetRecipesForMenuSelectionAsync().Returns(expectedResult);
        
        // Act
        var result = await _underTest.MenuSelection();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IList<MenuSelectionViewModel>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task GetShoppingList_Called_ReturnsValidView()
    {
        // Arrange
        var parameters = new List<MenuSelectionViewModel>()
        {
            new() { RecipeId = 1, RecipeName = "Test1", IsSelected = true },
            new() { RecipeId = 1, RecipeName = "Test2", IsSelected = false }
        };
        
        var expectedResult = new Dictionary<string, int>
        {
            { "Test1", 1 },
            { "Test2", 2 }
        };

        _shoppingListService.GetShoppingListAsync(Arg.Any<IEnumerable<int>>()).Returns(expectedResult);

        // Act
        var result = await _underTest.ShoppingList(parameters);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<Dictionary<string, int>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedResult);
    }
}