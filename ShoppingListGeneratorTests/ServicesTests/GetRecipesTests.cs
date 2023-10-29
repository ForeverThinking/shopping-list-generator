using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;
using FluentAssertions;

namespace ShoppingListGeneratorTests.ServicesTests;

public class GetRecipesTests : TestWithSqlite
{
    private readonly ShoppingListGeneratorServices _underTest;

    public GetRecipesTests()
    {
        _underTest = new ShoppingListGeneratorServices(Context);
    }
    
    [Fact]
    public async Task GetRecipes_Called_ReturnsListOfRecipes()
    {
        // Arrange
        await SeedRecipes();
            
        var data = new List<Recipe>
        {
            new() { Id = 1, Name = "Greek Salad" },
            new() { Id = 2, Name = "Chicken Adobo" }
        };

        // Act
        var result = (await _underTest.GetAllRecipesAsync()).ToList();
        
        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(data);
    }
}