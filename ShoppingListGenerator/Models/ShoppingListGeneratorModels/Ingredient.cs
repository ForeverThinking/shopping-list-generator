using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class Ingredient
{
    [Key]
    public int IngredientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } = Enumerable.Empty<RecipeIngredient>();
}