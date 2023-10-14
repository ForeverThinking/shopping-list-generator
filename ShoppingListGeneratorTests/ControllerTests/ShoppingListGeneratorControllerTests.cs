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
    public void GetRecipes_Called_ReturnsValidView()
    {
        // Arrange
        var expectedResult = new List<Recipe>()
        {
            new() { Id = 1, Name = "Greek Salad" },
            new() { Id = 2, Name = "Chicken Adobo" }
        };
        
        _shoppingListService.GetAllRecipes().Returns(expectedResult);
        
        // Act
        var result = _underTest.GetRecipes();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IList<Recipe>>(viewResult.ViewData.Model);
        model.Should().BeEquivalentTo(expectedResult);
    }
}