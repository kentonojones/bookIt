// File: src/bookIt.Domain/Entities/AuditLog.cs
namespace bookIt.Domain.Entities;

public class AuditLog : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public string Action { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty; // Stored as a JSON string

    // Foreign Key and Navigation Property for User
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}