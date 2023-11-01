using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class IngredientModel
{
    [Key]
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}