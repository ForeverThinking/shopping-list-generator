using FluentAssertions;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;

namespace ShoppingListGeneratorTests.ServicesTests;

public class IngredientsTests : TestWithSqlite
{
    private readonly ShoppingListGeneratorServices _underTest;

    public IngredientsTests()
    {
        _underTest = new ShoppingListGeneratorServices(Context);
    }

    [Fact]
    public async Task GetIngredients_Called_ReturnsListOfIngredients()
    {
        // Arrange
        await SeedIngredients();
        
        var data = new List<IngredientModel>()
        {
            new() { Id = 1, Name = "Red Onion" },
            new() { Id = 2, Name = "Olives" }
        };

        // Act
        var result = (await _underTest.GetAllIngredientsAsync()).ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(data);
    }
}