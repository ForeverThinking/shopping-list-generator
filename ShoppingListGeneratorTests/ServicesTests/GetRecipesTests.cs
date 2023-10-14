using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;
using FluentAssertions;

namespace ShoppingListGeneratorTests.ServicesTests;

public class GetRecipesTests
{
    private readonly ShoppingListGeneratorServices _underTest = new();

    [Fact]
    public void GetRecipes_Called_ReturnsListOfRecipes()
    {
        // Arrange
        var expectedResult = new List<Recipe>()
        {
            new() { Id = 1, Name = "Greek Salad" },
            new() { Id = 2, Name = "Chicken Adobo" }
        };

        // Act
        var result = _underTest.GetAllRecipes();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedResult);
    }
}