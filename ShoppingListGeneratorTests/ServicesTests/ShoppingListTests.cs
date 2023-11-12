using FluentAssertions;
using ShoppingListGenerator.Services;

namespace ShoppingListGeneratorTests.ServicesTests;

public class ShoppingListTests : TestWithSqlite
{
    private readonly ShoppingListGeneratorServices _underTest;

    public ShoppingListTests()
    {
        _underTest = new ShoppingListGeneratorServices(Context);
    }

    [Fact]
    public async Task GetShoppingList_Called_ReturnsDictionaryOfIngredients()
    {
        // Arrange
        await SeedRecipeIngredients();
        
        var testRecipeIds = new List<int> { 1 };

        var expectedData = new Dictionary<string, int>
        {
            { "Red Onion", 1 },
            { "Olives", 2 },
        };

        // Act
        var result = await _underTest.GetShoppingListAsync(testRecipeIds);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expectedData);
    }
}