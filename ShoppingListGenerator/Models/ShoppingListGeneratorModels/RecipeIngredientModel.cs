namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public sealed class RecipeIngredientModel
{
    public int RecipeId { get; init; }
    public RecipeModel? Recipe { get; init; }
    
    public int IngredientId { get; init; }
    public IngredientModel? Ingredient { get; init; }
    
    public int Quantity { get; init; }
}