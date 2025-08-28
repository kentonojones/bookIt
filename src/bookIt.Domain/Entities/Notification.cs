// File: src/bookIt.Domain/Entities/Notification.cs
namespace bookIt.Domain.Entities;

public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // e.g., Email, SMS
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }

    // Foreign Key and Navigation Property for User
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}