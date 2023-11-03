using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class IngredientModel
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public string? Name { get; init; }

    public ICollection<RecipeIngredientModel>? RecipeIngredient { get; init; }
}