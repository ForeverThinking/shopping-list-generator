using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class RecipeIngredient
{
    [Key]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = new();

    [Key]
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = new();

    public int Quantity { get; set; }
}