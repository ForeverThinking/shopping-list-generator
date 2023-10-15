using FluentAssertions;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;

namespace ShoppingListGeneratorTests.ServicesTests;

public class GetIngredientsTests
{
    private readonly ShoppingListGeneratorServices _underTest = new();

    [Fact]
    public void GetIngredients_Called_ReturnsListOfIngredients()
    {
        // Arrange
        var expectedResult = new List<Ingredient>()
        {
            new() { IngredientId = 1, Name = "Red Onion" },
            new() { IngredientId = 2, Name = "Olives" }
        };

        // Act
        var result = _underTest.GetAllIngredients();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedResult);
    }
}