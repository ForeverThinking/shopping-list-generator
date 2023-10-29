using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class Ingredient
{
    [Key]
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public IEnumerable<RecipeIngredient> RecipeIngredients { get; init; } = Enumerable.Empty<RecipeIngredient>();
}