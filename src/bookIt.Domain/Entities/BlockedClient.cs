// File: src/bookIt.Domain/Entities/BlockedClient.cs
namespace bookIt.Domain.Entities;

public class BlockedClient
{
    // Composite Primary Key would be configured in DbContext
    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}