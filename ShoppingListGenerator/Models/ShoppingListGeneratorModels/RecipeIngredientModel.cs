using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class RecipeIngredientModel
{
    public int RecipeId { get; init; }
    public int IngredientId { get; init; }
    public int MeasurementId { get; init; }
}