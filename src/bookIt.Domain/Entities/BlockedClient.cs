// File: src/bookIt.Domain/Entities/BlockedClient.cs
namespace bookIt.Domain.Entities;

public class BlockedClient
{
    // NOTE: This class uses a composite primary key.
    // See Step 3 in the API guide for DbContext configuration.
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}