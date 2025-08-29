// File: src/bookIt.Domain/Entities/Inventory.cs
namespace bookIt.Domain.Entities;

public class Inventory
{
    // NOTE: This class uses a composite primary key.
    // See Step 3 in the API guide for DbContext configuration.
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int LocationId { get; set; }
    public virtual Location Location { get; set; } = null!;

    public int Quantity { get; set; }
}