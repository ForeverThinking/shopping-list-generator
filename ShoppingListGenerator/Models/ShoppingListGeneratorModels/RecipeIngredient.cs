using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class RecipeIngredient
{
    [Key]
    public int RecipeId { get; init; }
    public Recipe Recipe { get; init; } = null!;

    [Key]
    public int IngredientId { get; init; }
    public Ingredient Ingredient { get; init; } = null!;

    public int Quantity { get; init; }
}