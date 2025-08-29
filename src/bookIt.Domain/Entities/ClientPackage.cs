// File: src/bookIt.Domain/Entities/ClientPackage.cs
namespace bookIt.Domain.Entities;

public class ClientPackage : BaseEntity
{
    public int SessionsLeft { get; set; }

    // Foreign Keys and Navigation Properties
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int PackageId { get; set; }
    public virtual Package Package { get; set; } = null!;
}