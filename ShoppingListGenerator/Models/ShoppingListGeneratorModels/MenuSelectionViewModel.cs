namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public sealed class MenuSelectionViewModel
{
    public int RecipeId { get; init; }
    public string? RecipeName { get; init; }
    public bool IsSelected { get; init; }
}