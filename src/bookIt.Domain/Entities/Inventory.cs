// File: src/bookIt.Domain/Entities/Inventory.cs
namespace bookIt.Domain.Entities;

public class Inventory
{
    // Composite Primary Key would be configured in DbContext
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int LocationId { get; set; }
    public virtual Location Location { get; set; } = null!;

    public int Quantity { get; set; }
}