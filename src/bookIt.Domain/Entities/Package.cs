// File: src/bookIt.Domain/Entities/Package.cs
namespace bookIt.Domain.Entities;

public class Package : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int NumberOfSessions { get; set; }

    // Foreign Key and Navigation Property for Service
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; } = null!;
}