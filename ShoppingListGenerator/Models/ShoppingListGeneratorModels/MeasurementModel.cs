using System.ComponentModel.DataAnnotations;

namespace ShoppingListGenerator.Models.ShoppingListGeneratorModels;

public class MeasurementModel
{
    [Key]
    public int Id { get; init; }

    public int Quantity { get; init; }
}