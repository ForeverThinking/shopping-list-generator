using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class Recipe
{
    [Key]
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public IEnumerable<RecipeIngredient> RecipeIngredients { get; init; } = Enumerable.Empty<RecipeIngredient>();
}