using FluentAssertions;
using ShoppingListGenerator.Models.ShoppingListGeneratorModels;
using ShoppingListGenerator.Services;

namespace ShoppingListGeneratorTests.ServicesTests;

public class GetRecipesForMenuSelectionTests : TestWithSqlite
{
    private readonly ShoppingListGeneratorServices _underTest;

    public GetRecipesForMenuSelectionTests()
    {
        _underTest = new ShoppingListGeneratorServices(Context);
    }

    [Fact]
    public async Task GetRecipesForMenuSelection_Called_ReturnsListOfMenuViewModels()
    {
        // Arrange
        await SeedRecipes();

        var expectedData = new List<MenuSelectionViewModel>
        {
            new() { RecipeId = 1, RecipeName = "Greek Salad", IsSelected = false },
            new() { RecipeId = 2, RecipeName = "Chicken Adobo", IsSelected = false },
        };

        // Act
        var result = (await _underTest.GetRecipesForMenuSelectionAsync()).ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedData);
    }
}