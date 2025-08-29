// File: src/bookIt.Domain/Entities/ClientProfile.cs
namespace bookIt.Domain.Entities;

public class ClientProfile : BaseEntity
{
    public string Notes { get; set; } = string.Empty;

    // Foreign Keys and Navigation Properties
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int BusinessId { get; set; }
    public virtual Business Business { get; set; } = null!;
}